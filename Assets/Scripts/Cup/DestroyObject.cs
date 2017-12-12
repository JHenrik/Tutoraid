using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour 
{
	public float lifetime;  //...how long spill effects last in the scene

	
	// Update is called once per frame
	void FixedUpdate () 
	
	{
		//...reduce lifetime using a constant amount				
		lifetime -= Time.deltaTime;

		//...Destroy the gameObject once lifetime is over
		if (lifetime <= 0)
		{
			Destroy (gameObject);
		}
		
	}
}
