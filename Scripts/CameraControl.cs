using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform rocket;
	
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
    
	void Start()
	{
		offset = new Vector3(3,5,8);
	}
	
	void FixedUpdate()
	{
		Vector3 nextPosition = rocket.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position,nextPosition,smoothSpeed);
		transform.position = smoothedPosition;
		transform.LookAt(rocket);
	}
	
}
