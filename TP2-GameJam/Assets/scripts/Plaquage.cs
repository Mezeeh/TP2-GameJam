using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaquage : MonoBehaviour {

	public AudioClip plaquage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.transform.tag == "Hero")
		{
			AudioSource source = GetComponent<AudioSource> ();
			source.PlayOneShot (plaquage, 0.2f);
			GestionLevel.vies--;
		}
	}
}
