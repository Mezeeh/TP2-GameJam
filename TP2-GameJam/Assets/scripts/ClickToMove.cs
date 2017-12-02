using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour {

    
    public float vitesse = 5;
    
    public Vector3 positionCible;
    private bool enMouvement;
	private PathFinding pathfinder;
	private int i;
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

        

        if (Input.GetMouseButton (0)) {
			if (enMouvement == false)
				enMouvement = true;


			else if(enMouvement)//cancel le movement deja en cours
				positionCible = transform.position;
                
            positionCible = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			positionCible.z = transform.position.z;

			noeudDepart = grille.noeudVsPoint (transform.position);
			noeudArriver = grille.noeudVsPoint (positionCible);
		

			pathfinder.trouverChemin (noeudDepart, noeudArriver);
			i = 0;

		}
		if (enMouvement) {
			Debug.Log (grille.chemin [i]);
			transform.position = Vector3.MoveTowards (transform.position, grille.chemin[i].position , vitesse * Time.deltaTime);

			Debug.Log (i);

			i++;


		}
		if (positionCible == transform.position) 
			enMouvement = false;


      /*  float AngleRad = Mathf.Atan2(positionCible.y - this.transform.position.y, positionCible.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
*/

		animateur.SetBool ("deplacement", enMouvement);
    }

    

}