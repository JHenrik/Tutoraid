using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{

	public int maxHealth = 100;    //... Maximum value of enemy health
    public int curHealth;        //... Enemy's current health amount
    public int scoreAmount = 10;   //...Points gained when enemy dies


    private BoxCollider2D boxCollider2D;  //... refers to enemy's box collider
    private Animator enemyAC;  //... enemy's animator controller
    private bool dead;   //... checks whether the enemy is dead


        void Start ()
        {
            //... Assigning of references and values.
            enemyAC = GetComponent<Animator> ();

			curHealth = maxHealth;

			boxCollider2D = GetComponent<BoxCollider2D> ();

			
        }


        void Update ()
        {
			//... Ensure enemy's health has a max value of 100
			if (curHealth > 100)
			{
				curHealth = maxHealth;
			}

        }


        public void GetDamage (int amount)
        {
            //... Dead enemies don't get further damage
            if(dead == true)
			{
                return;
			}

            curHealth -= amount;  //...How to reduce enemy health
            
            //...Check if the enemy is dead
            if(curHealth <= 0)
            {
                Death ();
            }
        }


        void Death ()
        {
            dead = true;  //... set the dead bool value to true

            enemyAC.SetTrigger ("Dead");  //... Kill the enemy and play the dead animation

			boxCollider2D.isTrigger = true; //...This makes it possible for the player to walk past the enemy

            //ScoreManager.score += scoreAmount;  //...gives the player score points

            Destroy (gameObject, 2f);  //..Destroys the gameObject

        }
    
}
