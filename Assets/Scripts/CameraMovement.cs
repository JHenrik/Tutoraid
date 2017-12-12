using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;
	public float posY;
	public float minY;
	public float MaxY;

	private Vector3 velocity = Vector3.zero;
	
	// Update is called once per frame
	void Update () 
	{
		//...Get player's position and set as target position
		Vector3 Targetposition = target.TransformPoint (new Vector3 (0, posY, -10));
		
		//...Smooth the camera movement 
		Vector3 PreferedPosition = Vector3.SmoothDamp (transform.position, Targetposition, ref velocity, smoothTime);
		
		//..clamp the camera so it does not go beyond set x and y cordinate values
		transform.position = new Vector3 (PreferedPosition.x, Mathf.Clamp (PreferedPosition.y, minY, MaxY), PreferedPosition.z);
	}

}
