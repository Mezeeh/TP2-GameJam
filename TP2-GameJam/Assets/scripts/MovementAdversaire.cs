using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAdversaire : MonoBehaviour {
	
	public float vitesse = 5;
	private PathFinding pathfinder;
	private Grille grille;
	private Vector3 positionCible;
	private Noeud noeudDepart, noeudArrivee;
	private GameManagerUn manager;
	private bool aggresser; 
	private int pointActuel;
	private bool reverse;
	private int derniereTuile;

	// Use this for initialization
	void Start () {
		aggresser = false;

		pathfinder = GameObject.Find ("A*").GetComponent<PathFinding> ();
		grille = GameObject.Find ("A*").GetComponent<Grille> ();
		manager = GameObject.Find ("gameManager").GetComponent<GameManagerUn> ();
		reverse = false;
		Debug.Log (manager.positionCible);
		SetRoute ();




	}
	
	// Update is called once per frame
	void Update () {
		if (grille.chemin != null) {
			if (transform.position != grille.chemin [derniereTuile].position) {
				Deplacement ();
			} else
				SetRoute ();
		}

		
	}
	private void SetRoute(){
		noeudDepart = grille.noeudVsPoint (transform.position);
		noeudArrivee = grille.noeudVsPoint (manager.positionCible); 
		if (!reverse) {
			pathfinder.trouverChemin (noeudDepart, noeudArrivee);
			reverse = true;
		} else {
			pathfinder.trouverChemin (noeudArrivee, noeudDepart);
			reverse = false;
		}
		pointActuel = 0;
		derniereTuile = grille.chemin.Count - 1;

	}

	private void Deplacement()
	{
		Vector3 direction = transform.position - grille.chemin [pointActuel].position;

		if (direction.magnitude < .1)
			pointActuel++;
		else
			transform.position = Vector3.MoveTowards (transform.position, grille.chemin [pointActuel].position, vitesse * Time.deltaTime);
	
	}
}
