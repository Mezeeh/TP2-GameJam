using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour {

    
    public float vitesse = 5;
    
    public Vector3 positionCible;
    private bool enMouvement;
	private PathFinding pathfinder;
	private int pointActuel;
	private Noeud noeudDepart, noeudArriver;
	private Grille grille;
	public Animator animateur;


	void Start () {
        
        
		positionCible = transform.position;
		grille = GameObject.Find("A*").GetComponent<Grille>();
        
		enMouvement = false;
		pathfinder = GameObject.Find ("A*").GetComponent<PathFinding> ();


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (1))
			enMouvement = false;
		
		

        if (Input.GetMouseButton (0)) {
			
			 if(enMouvement)//cancel le movement deja en cours
				positionCible = transform.position;
                
            positionCible = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			positionCible.z = transform.position.z;

			if (transform.position != positionCible) {
				noeudDepart = grille.noeudVsPoint (transform.position);
				noeudArriver = grille.noeudVsPoint (positionCible);
				if (noeudArriver.walkable && noeudDepart != noeudArriver) {

					if (enMouvement == false)
						enMouvement = true;

					pathfinder.trouverChemin (noeudDepart, noeudArriver);
					pointActuel = 0;
				}
			}

				
		}
		if(enMouvement && pointActuel != grille.chemin.Count){
			Vector3 target = grille.chemin [pointActuel].position;
			Vector3 direction = target - transform.position;

			if (direction.magnitude < .1)
				pointActuel++;
			else
				transform.position = Vector3.MoveTowards (transform.position, target, vitesse * Time.deltaTime);
		}
		if (grille.chemin == null)
			enMouvement = false;
		
		else if(grille.chemin.Count == pointActuel)
			enMouvement = false;






        float AngleRad = Mathf.Atan2(positionCible.y - this.transform.position.y, positionCible.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);


		animateur.SetBool ("deplacement", enMouvement);
    }

    

}