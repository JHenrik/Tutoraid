using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Player player;

    private void Start()
    {
        // Call the player Script from the Player
        player = gameObject.GetComponentInParent<Player>();
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded = false;
    }
}
