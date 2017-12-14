using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSound : MonoBehaviour 
{
public AudioSource throwSound;


	// Use this for initialization
	void Start () 
	{
		throwSound = GetComponent<AudioSource>();


	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void PlayThrowSound ()
	{
		throwSound.Stop ();

		throwSound.Play ();
	}
}
