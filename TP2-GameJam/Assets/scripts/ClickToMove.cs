using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour {

    
    public float vitesse = 5;
    
    private Vector3 positionCible;
    private bool enMouvement;
	private PathFinding pathfinder;
	private int i;
    

	void Start () {
        
        
		positionCible = transform.position;
        
		enMouvement = false;
		pathfinder = new PathFinding ();

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
			pathfinder.trouverChemin (transform.position, positionCible);
			i = 0;

		}
		if (enMouvement) {
			transform.position = Vector3.MoveTowards (transform.position, pathfinder.chemin [i].position, vitesse * Time.deltaTime);
			i++;
		}
		if (positionCible == transform.position) 
			enMouvement = false;


        float AngleRad = Mathf.Atan2(positionCible.y - this.transform.position.y, positionCible.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

    }

    

}