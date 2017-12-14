using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour 
{
	public string startScene;

	void Update () 
	{
		
	}

	public void StartGame ()
	{
		SceneManager.LoadScene (startScene);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
