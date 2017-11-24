using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour {
	
		private Button Button1;
		private Button Button2;


		// Use this for initialization
		void Start () {
		
			Debug.Log ("start");

			Button1 = GameObject.Find ("Button1").GetComponent<Button> ();
			Button1.onClick.AddListener (() => changeRoom ("Forward"));


		}
		private void changeRoom (string Direction){
			Debug.Log ("move");
			SceneManager.LoadScene ("TutoraidAssets/Scene2");


		}
	}