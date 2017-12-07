using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour 
{
	public GameObject bullet;
	public Vector3 positionLeft;
	public Vector3 positionRight;
	public int ammo;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		positionLeft = new Vector3 (transform.position.x - 0.7f, transform.position.y);
		positionRight = new Vector3 (transform.position.x + 0.7f, transform.position.y);
		if (Input.GetKeyDown (KeyCode.B) && ammo > 0) {
			//if (Playermovement.directionFacing == 1) {
				//ShootLeft ();
			//} else if (Playermovement.directionFacing == 2) {
				//ShootRight ();
			}
		}
	void ShootLeft(){
		Instantiate (bullet, positionLeft, Quaternion.identity);
		ammo--;
	}

	void ShootRight(){
		Instantiate (bullet, positionRight, Quaternion.identity);
		ammo--;
	}
}
