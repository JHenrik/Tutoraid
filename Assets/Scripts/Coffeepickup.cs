﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffeepickup : MonoBehaviour {

	public int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

		void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player"){
			Destroy(gameObject);
			score ++;
			Debug.Log ("score " + score);
		}
	}
}