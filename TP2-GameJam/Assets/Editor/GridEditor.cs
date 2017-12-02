using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Grid))] // spécifie que notre classe Editor sera basée sur la classe Grid

//ne pas oublier que ce Script doit obligatoirement être dans le répertoire Editor de notre projet
public class GridEditor : Editor //va hériter de Editor pour surcharger l'éditeur de Unity 
{
	Grid grid;
	private bool keyPressed = false;

	public void OnEnable() //va activer le scirpt quand on est en édition
	{
		grid = (Grid)target;

		SceneView.onSceneGUIDelegate += GridUpdate;
	}

	public void OnDisable() //va désactiver le scipt quand on est au run-time
	{
		SceneView.onSceneGUIDelegate -= GridUpdate;
	}

	public void GridUpdate(SceneView sceneView)
	{
		Event e = Event.current; //récupère l'événement en cours.

		//Debug.Log (e.ToString ());

		Ray rayon = Camera.current.ScreenPointToRay 
			(new Vector3 (e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));

		Vector3 mousePos = rayon.origin;

		//si tu tape un bouton, que ce bouton esy ctrl et qu'on vient de le taper
		if (e.ToString () == "Repaint" && e.control && !keyPressed) 
		{
			keyPressed = true;

			GameObject obj;
			Object prefab = PrefabUtility.GetPrefabParent (Selection.activeObject); //va récupérer la référence du prefab sélectionné dans notre éditeur

			//va instancier notre objet prefab et placer sa référence dans la variable obj qui est un GameObject
			obj = (GameObject)PrefabUtility.InstantiatePrefab (prefab);

			//ce vecteur va déterminer le milieu de la cellule sur laquelle notre curseur de la souris se trouve
			Vector3 aligned = new Vector3 (
				Mathf.Floor(mousePos.x / grid.width) * grid.width + grid.width * .5f,
				Mathf.Floor(mousePos.y / grid.height) * grid.height + grid.height * .5f,
				0.0f
			);

			obj.transform.position = aligned; //modifie la position de notre prefab en fonction de la position de la souris vs la grille
		}
		else if (e.ToString () == "Repaint" && e.control && keyPressed) //si je relache le bouton ctrl
			keyPressed = false;

		//Debug.Log ("salut"); permet d'écrire dans la fenêtre console, la même qui inscrit les warning et les erreurs
	}
}
