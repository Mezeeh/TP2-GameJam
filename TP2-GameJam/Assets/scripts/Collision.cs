using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	bool joueurControle = false;
	Vector3 joueurControleStartLocalPos = Vector3.zero;
	Vector3 joueurPalettePos;
	float joueurPaletteProgression;
	public float vitesseTir = 500.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(joueurControle)
		{
			joueurPaletteProgression += Time.deltaTime / 0.5f;
			transform.localPosition = Vector3.Lerp(joueurControleStartLocalPos, joueurPalettePos, joueurPaletteProgression);

			if(Input.GetKeyUp(KeyCode.Space))
			{
				this.transform.parent = null;
				joueurControle = false;
				tirer ();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(!joueurControle && coll.transform.tag == "Hero")
		{
			joueurPaletteProgression = 0;
			this.transform.parent = coll.transform;
			joueurControle = true;
			joueurControleStartLocalPos = transform.localPosition;
			joueurPalettePos = transform.parent.Find ("Palette").transform.localPosition;
		}
	}

	void tirer()
	{
		this.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * vitesseTir);
	}
}
