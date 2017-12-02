using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour {

	public GameObject mainMenu,
				menuCommentJouer,
				menuTouches;

	public void quitter()
	{
		Debug.Log ("Le jeu va se fermer!");
		Application.Quit ();
	}

	public void commentJouer()
	{
		//GetComponent ("Main Menu").gameObject.SetActive = false;
		menuCommentJouer.SetActive (true);
		mainMenu.SetActive (false);
	}

	public void touches()
	{
		menuTouches.SetActive (true);
		mainMenu.SetActive (false);
	}

	public void jouer()
	{
		mainMenu.SetActive (false);
		menuCommentJouer.SetActive (false);
		menuTouches.SetActive (false);
	}

	public void retour()
	{
		mainMenu.SetActive (true);
		menuCommentJouer.SetActive (false);
	}
}
