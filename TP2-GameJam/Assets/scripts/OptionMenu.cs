using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour {

	public GameObject menuPrincipal,
				menuCommentJouer,
				menuTouches,
				menus;

	public void quitter()
	{
		Debug.Log ("Le jeu va se fermer!");
		Application.Quit ();
	}

	public void commentJouer()
	{
		menuCommentJouer.SetActive (true);
		menuPrincipal.SetActive (false);
	}

	public void touches()
	{
		menuTouches.SetActive (true);
		menuPrincipal.SetActive (false);
	}

	public void jouer()
	{
		menuPrincipal.SetActive (false);
		menuCommentJouer.SetActive (false);
		menuTouches.SetActive (false);
		menus.GetComponent<AudioSource> ().Stop ();
	}

	public void retour()
	{
		menuPrincipal.SetActive (true);
		menuCommentJouer.SetActive (false);
		menuTouches.SetActive (false);
	}
}
