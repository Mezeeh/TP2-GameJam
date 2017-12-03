using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour {

	public Text textVies;
	public Text textPoints;
	public Text textLevel;

	public static Interface instance;

	// Use this for initialization
	void Start () 
	{
		instance = this;

		textVies.text = "3";
		textPoints.text = "0";
		textLevel.text = "1";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void updateVies(string textVies)
	{
		this.textVies.text = textVies;
	}

	public void updatePoints(string textPoints)
	{
		this.textPoints.text = textPoints;
	}

	public void updateLevel(string textLevel)
	{
		this.textLevel.text = textLevel;
	}
}
