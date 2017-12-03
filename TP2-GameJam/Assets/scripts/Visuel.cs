using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Visuel : MonoBehaviour {

	public Text textVies;
	public Text textPoints;
	public Text textLevel;
	public Text textTemps;

	public static Visuel instance;

	// Use this for initialization
	void Start () 
	{
		instance = this;

		textVies.text = "3";
		textPoints.text = "0";
		textLevel.text = "1";
		textTemps.text = "0:00:00";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GestionLevel.buts != null)
			textPoints.text = GestionLevel.buts.ToString ();

		if (GestionLevel.vies != null)
		{
			textVies.text = GestionLevel.vies.ToString ();
			if (GestionLevel.vies == 0)
				SceneManager.LoadScene (2);
		}

		if(GestionLevel.level != null)
		{
			textLevel.text = GestionLevel.level.ToString();
			if(GestionLevel.level > 5)
			{
				SceneManager.LoadScene (2);
			}
		}
	}
}
