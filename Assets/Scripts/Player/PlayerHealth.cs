﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	public int CurrentHP;    //player's current health
	public int MaxHP = 100;	//player maximum health
	public Slider healthBar;  //reference to healthbar
	public Image conversionImage;  //gui that flashes when damaged
	public float imageFlashSpeed = 4f; //how fast the image flashes
	public Color damageColor = new Color (0.75f, 0.04f, 0.04f, 0.1f);  //damage color

	private Animator healthAnim;              //Reference to player health
	private Playermovement playerMvScript;    //Reference to player movement script   
	private bool dead;
	private bool damage;
	private AudioSource playerHurtSound;
	private AudioSource playerdeadSoundEffects;


	// Use this for initialization
	void Start () 
	{
		//the player starts the game with full Health Points
		CurrentHP = MaxHP;
		
		//..assigning the health and player movement on start
		healthAnim = GetComponent <Animator> ();
		playerMvScript = GetComponent <Playermovement> ();
		playerHurtSound = GetComponent<AudioSource> ();
		playerdeadSoundEffects = GameObject.Find("PlayerDeadSoundManager").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		// Current HP can not be over the max HP
		if (CurrentHP > MaxHP) 
		{
			CurrentHP = MaxHP;
		}

    	// check whether the player has been damaged
        if(damage == true)
        {
            conversionImage.color = damageColor;  //set canvas image color
			playerHurtSound.Stop ();
			playerHurtSound.Play ();

        }
        else
        {
			//Maintain initial canvas color
            conversionImage.color = Color.Lerp (conversionImage.color, Color.clear, imageFlashSpeed * Time.deltaTime);
        }

		// ensure damage is false again or reset
        damage = false;

    }

	public void GetDamage (int amount)
	{
        damage = true;

        CurrentHP -= amount; //reduce player's current health value
        
        healthBar.value = CurrentHP; // Set the health bar's value to the current health.

        //When current health goes below 0 it will trigger a Death method
        if(CurrentHP <= 0 && !dead)
        {
            Death ();
        }
	}

	private void Death()
	{
		// when player CurrentHP goes under 0 it will trigger these actions

        dead = true;

		playerdeadSoundEffects.Play ();

        healthAnim.SetTrigger ("Dead");  // sets the death animation

        playerMvScript.enabled = false;    // Disables player movement

		StartCoroutine (ScreenDelay ());

	}
	//Waits 3 sec before loading game over scene
	IEnumerator ScreenDelay(){
		if (CurrentHP <= 0)
			yield return new WaitForSeconds(3);
			SceneManager.LoadScene ("GameOver");
	}

}
