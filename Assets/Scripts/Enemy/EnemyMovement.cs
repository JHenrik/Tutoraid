using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField]
	private Transform targetOne;   //..patrol target one

	[SerializeField]
	private Transform targetTwo;  //..patrol target two

	public Transform currentTarget;  //..current target enemy is moving towards
	private float move;    //..used to calculate how fast the enemy moves
	public float directionX;  //...direction of movement
	
	public float Step;  //...used as a condition for walking animation
	
	private Animator enemyAC;  //..refers to enemy's Animator controller
	private EnemyHealth enemyHealth;   //...Refers to the enemy health script


	public float enemySpeed = 2;   //..Value of enemy speed

	void Start ()
 	{
		//..Assigning some values
		directionX = 0.0f;
		currentTarget = targetOne;
		enemyAC = GetComponent<Animator> ();
		enemyHealth = GetComponent<EnemyHealth>();

	}

	void FixedUpdate () 
	{
		//...Check if enemy is close enough to target position and switch the targets
		if(Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
		{
			Switch ();
		}

		Movement (); //...call the movement method 	
		
	}

	void Movement ()
	{
		//..asigning the move speed.
		move = enemySpeed * Time.deltaTime;

		//...Check if enemy is still alive and allow movement
		if (enemyHealth.curHealth > 0)
		{
		//..moving the enemy towards the target at a given speed
		transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, move);			
		}

		//...Used to flip the enemy to face the right direction
		directionX = currentTarget.position.x - transform.position.x;

		//...Check the flip condition
		if (directionX < 0.0f)
		{
	    	transform.localScale = new Vector3 (-1, 1, 1);
		}
		else if (directionX > 0.0f)
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}

		//...Condition for triggering the enemy's walk animation
		 Step = Mathf.Abs(directionX);
		if (Step > 0.0f)
		{
			enemyAC.SetBool ("Walking", true);
		}else
		{
			enemyAC.SetBool ("Walking", false);		
		}
	}


	void Switch () 
	{
		//..Switching the target points.
		if(currentTarget == targetOne)
		{
			currentTarget = targetTwo;
		}
		else
		{
			currentTarget = targetOne;
		}
	}
}
