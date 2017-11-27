using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // properties
    public float maxSpeed = 3;
    public float speed = 50;
    public float jump = 150;

    //to see if player is on the ground or not 
    public bool grounded;


    private Rigidbody2D player;
    private Animator ani;

	void Start ()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponent<Animator>();
	}
	
	
	void Update ()
    {
        ani.SetBool("Grounded",grounded);
        ani.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetAxis("Horizontal") < -0.1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(Input.GetButtonDown ("Jump")&&grounded == true)
        {
            player.AddForce(Vector2.up * jump);
            
        }

        if(grounded && Input.GetButtonDown("Jump"))
        {
            player.AddForce(Vector2.up * jump);
            grounded = false;
        }
    }


    void FixedUpdate()
    {
        //moves the player with a,d or left right arrow keys
        float h = Input.GetAxis("Horizontal");

        player.AddForce(Vector2.right * speed * h);

        // cant go faster than maxSpeed
        if(player.velocity.x > maxSpeed)
        {
            player.velocity = new Vector2(maxSpeed, player.velocity.y);
        }
            if (player.velocity.x < -maxSpeed)
        {
            player.velocity = new Vector2(-maxSpeed, player.velocity.y);
        }
    }
}
