using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour 
{
	public float attackInterval = 0.6f;  //...Space between attacks
	public int attackAmount;    //....damage amount
	private PlayerHealth plHealth;   //....Reference to player health script
	private bool playerClose;   //....check if player has been detected
	private float attackSyncTimer;   //....maintains attacks at a constant time
	private Animator chaseAnim;  //....reference to enemy's animator

	
	[SerializeField]
	private Transform player; // reference to the player as a target
	[SerializeField]
	private Transform restart; // reference to a patrol target
	private GameObject playerObject;  //  reference to player gameobject
	private EnemyMovement enemyMovement; //..place holder for the enemymovement script


	private EnemyHealth enemyHealth;  //...Reference to the enemy health script

	void Start ()
	{
		//Assigning of values at start
		playerObject = GameObject.Find("Player");
		enemyMovement = GetComponent<EnemyMovement>();
		plHealth = playerObject.GetComponent<PlayerHealth>();
		chaseAnim = GetComponent<Animator>();
		enemyHealth = GetComponent<EnemyHealth>();
	}

	void Update ()
	{
		// syncronising time between attacks
        attackSyncTimer += Time.deltaTime;

		//check if player is close and still has health and that we are not currently attacking
        if(attackSyncTimer >= attackInterval && enemyHealth.curHealth > 0 && playerClose)
        {
            Attack ();
        }

        // If the player has zero or less health and enemy's health > 0 deactivate movement...
        if(plHealth.CurrentHP <= 0)
        {
            // ...Disable enemy movement and walking animations.
            enemyMovement.enabled = false;
			chaseAnim.SetBool ("Walking" , false);
        }
	}

    void Attack ()
    {
        attackSyncTimer = 0f; 

        // Check if player has health and give damage
        if(plHealth.CurrentHP > 0)
        {
            plHealth.GetDamage (attackAmount);
        }
    }


	void OnTriggerEnter2D (Collider2D col)
	{
		//... check if player has been detected
		if (col.tag == "Player")
		{
			enemyMovement.currentTarget = playerObject.transform;
			
			enemyMovement.enemySpeed = 3;  //..Increase enemy's speed to symbolize aggression

			playerClose = true;   
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		//...Once player leaves the detection zone...reset the target points
		if (col.tag == "Player")
		{
			
			enemyMovement.currentTarget = restart.transform;
			
			enemyMovement.enemySpeed = 2;   //...decrease enemy's speed

			playerClose = false; 
		}
	}	


}
