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
	void Update () {
		Vector3 Targetposition = target.TransformPoint (new Vector3 (0, posY, -10));
		Vector3 PreferedPosition = Vector3.SmoothDamp (transform.position, Targetposition, ref velocity, smoothTime);
		transform.position = new Vector3 (PreferedPosition.x, Mathf.Clamp (PreferedPosition.y, minY, MaxY), PreferedPosition.z);
	}

}
