using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;


	Animator anim;
	Player playerMovement;
	Shooting playerShooting;
	bool dead;
	bool damaged;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerMovement = GetComponent <Player> ();
		playerShooting = GetComponentInChildren <Shooting> ();

		currentHealth = startingHealth;
	}

	public void TakeDamage (int amount)
		{
		damaged = true;

		currentHealth -= 10;

		healthSlider.value = currentHealth;

		if(currentHealth <= 0 && !dead)
		{
			Death ();
		}
	}


	void Death ()
	{
		dead = true;

		playerShooting.DisableEffects ();

		anim.SetTrigger ("Die");

		playerMovement.enabled = false;
		playerShooting.enabled = false;
	}       
}
