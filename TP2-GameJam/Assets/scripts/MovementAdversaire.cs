using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAdversaire : MonoBehaviour {
	
	public float vitesse = 5;
	private PathFinding pathfinder;
	private Grille grille;
	private Vector3 positionCible;
	private Noeud noeudDepart, noeudArrivee;
	private BoardManager manager;
	private bool aggresser; 
	// Use this for initialization
	void Start () {
		aggresser = false;

		pathfinder = GameObject.Find ("A*").GetComponent<PathFinding> ();
		grille = GameObject.Find ("A*").GetComponent<Grille> ();



	}
	
	// Update is called once per frame
	void Update () {
		

		
	}
	private void SetRoute(){
		noeudDepart = grille.noeudVsPoint (transform.position);
		noeudArrivee = 

	}
}
