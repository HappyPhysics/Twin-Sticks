using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour {
	private Rigidbody thisRB;

	[HideInInspector]
	public Vector3 velocity;
	[HideInInspector]
	public float speed =  0;
	[HideInInspector]
	public Vector3 acceleration;
	[HideInInspector]
	public float AccelerationMag;

	// Use this for initialization
	void Start () {
		thisRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		getMeasurements ();
	}

	void getMeasurements () {
		acceleration = (thisRB.velocity - velocity) / Time.fixedDeltaTime;
		velocity = thisRB.velocity;
		float sign = Mathf.Sign(velocity.magnitude - speed);
		speed = velocity.magnitude;

		AccelerationMag = acceleration.magnitude*sign;

	}
}
