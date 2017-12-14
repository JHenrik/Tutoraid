using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeSounds : MonoBehaviour {
	public AudioSource splashSound;


	// Use this for initialization
	void Start () 
	{
		splashSound = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void PlayCupSound ()
	{
		splashSound.Play ();
	}
}
