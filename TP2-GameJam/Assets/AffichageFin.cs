using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageFin : MonoBehaviour {

	public Text textEtat;
	public Text textPoints;

	// Use this for initialization
	void Start () 
	{
		textEtat.text = GestionLevel.victorieux ? "You won!" : "You lost";
		textPoints.text = GestionLevel.buts.ToString() + " points";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
