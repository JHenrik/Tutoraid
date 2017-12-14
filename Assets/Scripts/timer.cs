using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

	public float timeLeft = 30;
	private Text textTimer;

	// Use this for initialization
	void Start () {
		textTimer = GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		textTimer.text = timeLeft.ToString ("f0");
		print (timeLeft);

		if (timeLeft < 0.1f) 
		{
			SceneManager.LoadScene ("GameOver");
		}
	}
}
