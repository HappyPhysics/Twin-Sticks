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
		if (Input.GetAxis ("Horizontal") != 0) {
			print(Input.GetAxis ("Horizontal"));
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
