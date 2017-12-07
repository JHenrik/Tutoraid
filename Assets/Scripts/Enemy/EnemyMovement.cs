using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField]
	private Transform targetOne;   //..patrol target one

	[SerializeField]
	private Transform targetTwo;  //..patrol target two

	public Transform currentTarget;  //..current target enemy is moving towards
	private float move;
	public float directionX;
	
	public float Step;
	
	private Animator enemyAC;


	public float enemySpeed = 2;

	void Start ()
 	{
		directionX = 0.0f;
		currentTarget = targetOne;
		enemyAC = GetComponent<Animator> ();

	}

	void FixedUpdate () 
	{

		if(Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
		{
			Switch ();
		}

		Movement (); 	
		
	}

	void Movement ()
	{
		//..asigning the move speed.
		move = enemySpeed * Time.deltaTime;

		//..moving the enemy towards the target at a given speed
		transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, move);

		directionX = currentTarget.position.x - transform.position.x;

		//Player Direction that is needed to flip the sprite
		if (directionX < 0.0f)
		{
	    	transform.localScale = new Vector3 (-1, 1, 1);
		}
		else if (directionX > 0.0f)
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}

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
