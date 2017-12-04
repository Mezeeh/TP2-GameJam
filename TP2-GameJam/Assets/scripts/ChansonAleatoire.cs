using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChansonAleatoire : MonoBehaviour {

	public AudioClip[] chansons;
	private AudioSource source;

	// Use this for initialization
	void Awake () 
	{
		source = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(source != null && !source.isPlaying)
		{
			source.PlayOneShot (randomChanson());
		}
	}

	AudioClip randomChanson()
	{
		return chansons[Random.Range(0, chansons.Length)];
	}
}
