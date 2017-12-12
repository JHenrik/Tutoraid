using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {


    
    public int LevelToLoad;

    void Start()
    {
      
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
				SceneManager.LoadScene(LevelToLoad);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("e"))
        {
			SceneManager.LoadScene(LevelToLoad);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

    }
}
