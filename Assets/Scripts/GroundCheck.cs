﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	private playermovement Player;

    private void Start()
    {
        // Call the player Script from the Player
		Player = gameObject.GetComponentInParent<playermovement>();
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Player.grounded = false;
    }
}
