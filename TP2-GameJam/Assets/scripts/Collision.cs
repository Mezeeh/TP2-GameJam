using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour {

	bool joueurControle = false;
	Vector3 joueurControleStartLocalPos = Vector3.zero;
	Vector3 joueurPalettePos;
	float joueurPaletteProgression;
	public float vitesseTir = 1f;
	public AudioClip pickUpRondelle;
	public AudioClip tirRondelle;
	public AudioClip sonBut;

	// Use this for initialization
	void Start () {
		Debug.Log (GestionLevel.buts);
	}
	
	// Update is called once per frame
	void Update () {
		if(joueurControle)
		{
			joueurPaletteProgression += Time.deltaTime / 0.5f;
			transform.localPosition = Vector3.Lerp(joueurControleStartLocalPos, joueurPalettePos, joueurPaletteProgression);

			if(Input.GetKeyUp(KeyCode.Space))
			{
				
				tirer ();
			}
		}
	}

	IEnumerator OnCollisionEnter2D(Collision2D coll)
	{
		if(!joueurControle && coll.transform.tag == "Hero")
		{
			joueurPaletteProgression = 0;
			this.transform.parent = coll.transform;
			joueurControle = true;
			joueurControleStartLocalPos = transform.localPosition;
			joueurPalettePos = transform.parent.Find ("Palette").transform.localPosition;

			AudioSource source = GetComponent<AudioSource> ();
			source.PlayOneShot (pickUpRondelle, 1f);
		}

        if(coll.transform.tag == "LigneBut")
        {
            Debug.Log("BUUUUUUUUUUUUUUUUUT");
			AudioSource source = GetComponent<AudioSource> ();
			source.PlayOneShot (sonBut, 1f);

			yield return new WaitForSeconds (sonBut.length);

			GestionLevel.buts += 3;
			GestionLevel.level++;
            GameManagerUn.instance.pointsJoueur++;
            SceneManager.LoadScene(0);
        }
	}

	void tirer()
	{
		/*
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 myPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1,0);
        Vector3 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        this.gameObject.transform.rotation = rotation;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * vitesseTir);
		*/


		Vector3 direction = this.transform.parent.transform.right;

		this.GetComponent<Rigidbody2D> ().AddForce (direction * 100f);
        
		this.transform.parent = null;
		joueurControle = false;

		AudioSource source = GetComponent<AudioSource> ();

		source.PlayOneShot (tirRondelle, 1f);
	}
}
