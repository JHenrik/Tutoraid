/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffeepickup : MonoBehaviour {

	public int score = 0;

	public Text coffeeText;
	public static int coffeeCup;

	// Use this for initialization
	void Start () 
	{
		coffeeCup = 0;
		SetCountText ();	
	}
	
	// Update is called once per frame
	void Update () {

	}

		void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player"){
			Destroy(gameObject);

			coffeeCup += 1;

			SetCountText ();
		
		}
	}


	void SetCountText ()
	{
		coffeeText.text = "Coffee collected " + coffeeCup.ToString();
	}
}*/