using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementController : MonoBehaviour {
	private float bulletRate = 5.0f;

	private float bulletTimer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetAxis ("Horizontal") != 0) {
			Vector3 ballPos = transform.position;
			ballPos.z += Input.GetAxis ("Horizontal") * Input.GetAxis ("Horizontal")*Input.GetAxis ("Horizontal");
			transform.position = ballPos;

		}

		if (Input.GetButton ("Fire1")) {
			bulletTimer += Time.deltaTime;

			if (bulletTimer > 1.0f / bulletRate) {
				print("fire");
				bulletTimer = 0;
			} 
		} 
	}
}
