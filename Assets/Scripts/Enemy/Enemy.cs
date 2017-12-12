using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	private Rigidbody2D enemy;
	private Animator ani;
	public bool grounded;

	public float speed;
	public float maxSpeed;
	public Vector2 move = new Vector2(1, 0);
	void Start () {
		enemy = GetComponent<Rigidbody2D> ();
		ani = gameObject.GetComponent<Animator>();
	}
	void Update (){
		ani.SetBool("Grounded",grounded);
		ani.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		if(Input.GetAxis("Horizontal") < -0.1)
		{
			transform.localScale = new Vector3(-1, 0, 0);
		}

		if (Input.GetAxis("Horizontal") > 0.1)
		{
			transform.localScale = new Vector3(1, 0, 0);
		}

		enemy.position += move * speed;
		enemy.velocity = (enemy.velocity.x > maxSpeed) ? new Vector2 (maxSpeed, enemy.velocity.y) : enemy.velocity;
		enemy.velocity = (enemy.velocity.x < -maxSpeed) ? new Vector2 (-maxSpeed, enemy.velocity.y) : enemy.velocity;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			Destroy (col.gameObject);
		else
			move.x *= -1;
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player")
			Destroy (this.gameObject);
	}
}	