using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadSound : MonoBehaviour 
{
public AudioSource playerDeadSound;


	// Use this for initialization
	void Start () 
	{
		playerDeadSound = GetComponent<AudioSource>();


	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void PlayDeadSound ()
	{
		playerDeadSound.Play ();
	}
}
