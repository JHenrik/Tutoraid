using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeThrow : MonoBehaviour 
{
	public float throwForce;   //...amount of force that moves the cup
	public GameObject coffeeSpill;  //...Spill particle effects

	private Rigidbody2D cupRigidBody;  //...reference to the rigidbody2D
	public List<GameObject> detectedEnemies;  //..refers to detected enemies
	public int damageAmount;


	void Start()
	{
		//...Assigning of components at start
		cupRigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{
		//...Throw the coffee at a certain velocity
		cupRigidBody.velocity = new Vector2 (throwForce * Time.deltaTime * transform.localScale.x, 0);

	}

	//...How to destroy the thrown coffee cup
	void OnCollisionEnter2D (Collision2D other)
	{
		//...We destroy the cup when it hits everything else other than the player and itself
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "Throwable")
		{
			Instantiate (coffeeSpill , transform.position , transform.rotation); //..Creates the Spill particle effects

			//...Give damage to the detected enemies
			foreach (GameObject enemy in detectedEnemies)
        	{
            	//Debug.Log (enemy.name + " receives 10 damage");
				EnemyHealth targetHealth = enemy.GetComponent<EnemyHealth> ();
				
				targetHealth.GetDamage(damageAmount);
        	}
			
			Destroy (gameObject); //..Destroys the cup from the scene.
		}

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "enemy")
		{
			//...Create a list of all game objects tagged enemy
			if (!detectedEnemies.Contains(other.gameObject))
        	{
            	detectedEnemies.Add(other.gameObject);
				//Debug.Log (other.gameObject.name + "has been Added to the list");
        	}
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "enemy")
		{
			//if the object is already in the list
     		if(detectedEnemies.Contains(other.gameObject))
     		{
         		//remove it from the list
         		detectedEnemies.Remove(other.gameObject);
				//Debug.Log (other.gameObject.name + "has been removed from list");
     		}
		}
	}


}