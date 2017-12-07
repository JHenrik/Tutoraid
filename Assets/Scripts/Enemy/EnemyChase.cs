using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour 
{
	
	[SerializeField]
	private Transform player; // reference to the player as a target
	[SerializeField]
	private Transform restart; // reference to a patrol target
	//public GameObject Enemy;
	private GameObject playerObject;

	private EnemyMovement enemyMovement; //..holder for the enemymovement script

void Start ()
{

	playerObject = GameObject.Find("Player");
	enemyMovement = GetComponent<EnemyMovement>();
}


	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player")
		{
			enemyMovement.currentTarget = playerObject.transform;
			
			enemyMovement.enemySpeed = 3;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Player")
		{
			
			enemyMovement.currentTarget = restart.transform;
			enemyMovement.enemySpeed = 2;
		}
	}	


}
