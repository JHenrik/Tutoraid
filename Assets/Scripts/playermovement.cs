using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour {


	// properties
	public float maxSpeed = 3;
	//Max speed
	public float speed = 100;
	// players speed
	public float jump = 150;
	// Height of the jump

	//to see if player is on the ground or not
	public bool grounded;

	//Player Health

	public int CurrentHP;
	//players current health
	public int MaxHP = 100;
	//player maximum health





	private Rigidbody2D player;
	// to identify player
	private Animator ani;
	// to find the animations

	void Start ()
	{
		//When game starts the player and animator are created
		player = gameObject.GetComponent<Rigidbody2D> ();
		ani = gameObject.GetComponent<Animator> ();

		//the player starts the game with full HP
		CurrentHP = MaxHP;

	}


	void Update ()
	{
		//player movement  
		ani.SetBool ("Grounded", grounded); // Boolean value to grounded
		ani.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal"))); // Float set to get the absolute value of speed 

		//when moving in the -x axis the player will have scale value x as minus so it will face the direction of movement
		if (Input.GetAxis ("Horizontal") < -0.1) {
			transform.localScale = new Vector3 (-1, 1, 1); // scale value when moving to -x
		}

		//when moving in the x axis the player will have scale value x as positive so it will face the direction of movement
		if (Input.GetAxis ("Horizontal") > 0.1) {
			transform.localScale = new Vector3 (1, 1, 1); // scale value when moving to x
		}

		//Player jumps
		if (Input.GetButtonDown ("Jump") && grounded == true) { // can jump only when grounded 
			player.AddForce (Vector2.up * jump); // when button is pressed it adds the vector of speed and jump force

		}

		if (grounded && Input.GetButtonDown ("Jump")) { // if player is in air it can't jump
			player.AddForce (Vector2.up * jump);
			grounded = false; // not able to jump
		}

		// Current HP cant be over the max HP
		if (CurrentHP > MaxHP) {
			CurrentHP = MaxHP;
		}
		//When current health goes below 0 it will trigger a Death method
		if (CurrentHP <= 0) { 

			Death ();
		}
		 
		if (Input.GetKeyDown (KeyCode.V)) { 
			ani.SetTrigger ("Throw");
		}

	}



	void FixedUpdate ()
	{
		//moves the player with a,d or left right arrow keys
		float h = Input.GetAxis ("Horizontal");

		player.AddForce (Vector2.right * speed * h);

		// cant go faster than maxSpeed
		if (player.velocity.x > maxSpeed) {
			player.velocity = new Vector2 (maxSpeed, player.velocity.y);
		}
		if (player.velocity.x < -maxSpeed) {
			player.velocity = new Vector2 (-maxSpeed, player.velocity.y);
		}

		var camera = GameObject.FindGameObjectWithTag ("MainCamera");

		camera.transform.position = new Vector3 (transform.position.x, camera.transform.position.y, camera.transform.position.z);

	}

	// when player CurrentHP goes under 0 will it will trigger these actions
	void Death ()
	{

		ani.SetTrigger ("Dead"); // death animation
		//make it so it can't move
		speed = 0f; 
		maxSpeed = 0f; 
		jump = 0f;
		//make a reset button so when "r" key is pressed it loads the first scene and you start again
		if (Input.GetKey ("r"))
			SceneManager.LoadScene (0);


	}

}

