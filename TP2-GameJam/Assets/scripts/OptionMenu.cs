using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour {

	public GameObject menuPrincipal,
		menuCommentJouer,
		menuTouches,
		menus,
		menuFinDePartie;

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
		SceneManager.LoadScene (1);
	}

	public void retour()
	{
		menuPrincipal.SetActive (true);
		menuCommentJouer.SetActive (false);
		menuTouches.SetActive (false);
	}

	public void recommencer()
	{
		GestionLevel.reset ();
		SceneManager.LoadScene (1);
	}
}
