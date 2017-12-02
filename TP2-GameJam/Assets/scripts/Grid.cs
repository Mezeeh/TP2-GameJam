using UnityEngine;
using System.Collections;
using UnityEditor; //package qui va nous permettre de modifier l'éditeur de unity lui-même

[AddComponentMenu("Custom/Editor")] //va rajouter le menu Custom/Editor dans le menu component de l'éditeur 

public class Grid : MonoBehaviour 
{
	public float width = 1.0f; //largeur d'une cellule dans ma grille
	public float height = 1.0f; //hauteur d'une cellule dans la grille
	public Color color = Color.yellow;  //couleur de la grille
	// Use this for initialization

	//cette méthode va dessiner une grille de 500 lignes par 500 colonnes centrée sur la camera active
	void OnDrawGizmos() //va permettre de dessiner sur la scene en mode edition
	{
		Vector3 pos = Camera.current.transform.position; //va chercher la position de la camera active

		//Gizmos sera la classe qui nous permettra de dessiner sur la scène en mode édition
		Gizmos.color = color; //attribution de la couleur des lignes qui seront tracées

		//cette boucle va tracer les 500 lignes en les centrant sur la position de la camera
		for (float y = pos.y - 250.0f; y < pos.y + 250.0f;  y += height)
		{//l'instruction suivante trace une ligne de 500 pixels de longueur et ajuste sa hauteur en fonction de la boucle
			Gizmos.DrawLine (
				new Vector3(-250.0f, Mathf.Floor(y / height) * height, 0.0f),
				new Vector3(250.0f, Mathf.Floor(y / height) * height, 0.0f)
			);
		}
		//cette boucle va tracer les 500 colonnes en les centrant sur la position de la camera
		for (float x = pos.x - 250.0f; x < pos.x + 250.0f;  x += width)
		{//l'instruction suivante trace une colonne de 500 pixels de longueur et ajuste sa position en X en fonction de la boucle
			Gizmos.DrawLine (
				new Vector3(Mathf.Floor(x / width) * width, -250.0f, 0.0f),
				new Vector3(Mathf.Floor(x / width) * width, 250.0f, 0.0f)
			);
		}
	}
}
