using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	private Playermovement Player;

    private void Start()
    {
        // Call the player Script from the Player
		Player = gameObject.GetComponentInParent<Playermovement>();
    
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
