using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour 
{
	public GameObject throwCup;  //place holder for the throw cup game object
	public Transform throwPoint;  //the point at which the cups will be thrown
	public float maxSpeed = 3;	//Max speed
	public float speed = 100;  // players speed
	public float jumpPower = 150; // Height of the jump

	public bool grounded; //to see if player is on the ground or not
	public float distanceToPlayerBase = 2.6f; //Used by raycast to check if player is grounded


	private float runAnimator; //used to trigger run animation
	private Rigidbody2D player; 	// to identify player
	private Animator ani;	// to find the animations

	void Start ()
	{
		//When game starts the player and animator are created
		player = gameObject.GetComponent<Rigidbody2D> ();
		ani = gameObject.GetComponent<Animator> ();

	}


	void Update ()
	{
		//..Moving code
		Moving ();


		//Player jumps
		if (Input.GetButtonDown ("Jump") && grounded == true) 
		{ 
			// can jump only when grounded 
			Jump ();
			ani.SetBool ("isJumping", true);

		}else if (!this.ani.GetCurrentAnimatorStateInfo(0).IsName("Jump")) 
		{
	    	ani.SetBool ("isJumping", false);
		}

		//...Throwing code
		if (Input.GetKeyDown (KeyCode.V)) 
		{
			//..Once button is pressed, we create a throw game object
			GameObject coffeeClone = (GameObject) Instantiate (throwCup, throwPoint.position, throwPoint.rotation); 
			
			//...Flips the throw direction in relation to the player
			coffeeClone.transform.localScale = transform.localScale * 0.04f;
			
			ani.SetTrigger ("Throw"); //..activates throw animation
		}

	}

	void Moving ()
	{
		//..Ensure player only runs when on the ground

		runAnimator = Mathf.Abs (Input.GetAxis ("Horizontal"));
		if (runAnimator != 0 && grounded == true)
		{
			ani.SetBool ("Running" , true);
		}else
		{
			ani.SetBool ("Running" , false);
		}

		//when moving in the -x axis the player will have scale value x as minus so it will face the direction of movement
		if (Input.GetAxis ("Horizontal") < -0.1) {
			transform.localScale = new Vector3 (-1, 1, 1); // scale value when moving to -x
		}

		//when moving in the x axis the player will have scale value x as positive so it will face the direction of movement
		if (Input.GetAxis ("Horizontal") > 0.1) {
			transform.localScale = new Vector3 (1, 1, 1); // scale value when moving to x
		}
	}

	void FixedUpdate ()
	{
		//moves the player with a,d or left right arrow keys
		float h = Input.GetAxis ("Horizontal");

		player.AddForce (Vector2.right * speed * h);

		// can't go faster than maxSpeed
		if (player.velocity.x > maxSpeed) {
			player.velocity = new Vector2 (maxSpeed, player.velocity.y);
		}
		if (player.velocity.x < -maxSpeed) {
			player.velocity = new Vector2 (-maxSpeed, player.velocity.y);
		}

		PlayerRaycast ();
	}

	void Jump ()
	{
		// ..code for jumping
		player.AddForce (Vector2.up * jumpPower);
		grounded = false;

	}

	void PlayerRaycast()
    {	
		//..creating the RayDown
		RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);

		if (rayDown.collider != null && rayDown.distance < distanceToPlayerBase && rayDown.collider.tag != "enemy")
		{
			//Debug.Log ("HitRay has hit " + rayDown.collider.name);
	    	grounded = true;

		}else
		{
			grounded = false;
		}
    }

}
 