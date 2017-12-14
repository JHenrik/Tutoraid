using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager GM;
	public GameObject playerPrefab;
	private GameObject respawnPoint;

	void Awake ()
	{
		if (GM == null)
		{
			GM = this;
		}else if (GM != this)
		{
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		respawnPoint = GameObject.FindGameObjectWithTag ("Respawn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
