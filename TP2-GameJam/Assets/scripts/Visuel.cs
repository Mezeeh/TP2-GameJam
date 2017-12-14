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
	private float time;
	private string timeMinutes;
	private string timeSeconds;

	// Use this for initialization
	void Start () 
	{
		instance = this;
		float time = 0;

		textVies.text = "3";
		textPoints.text = "0";
		textLevel.text = "1";
		textTemps.text = time.ToString();
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
				GestionLevel.victorieux = true;
				SceneManager.LoadScene (2);
			}
		}

		time += Time.deltaTime;
		timeMinutes = Mathf.Floor (time / 60).ToString ("00");
		timeSeconds = Mathf.RoundToInt (time % 60).ToString ("00");
		textTemps.text = timeMinutes + ":" + timeSeconds;
	}
}
