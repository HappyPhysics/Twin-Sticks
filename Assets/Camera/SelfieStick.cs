using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class SelfieStick : MonoBehaviour {

	public float rotSpeed = 2;

	private GameObject player;
	private Vector3 rotAngles;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		rotAngles = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;

		moveArm ();
	}

	void moveArm() {
		float v = CrossPlatformInputManager.GetAxis ("Mouse Y");
		float h = CrossPlatformInputManager.GetAxis ("Mouse X");

		rotAngles.y += rotSpeed * h;
		rotAngles.x += rotSpeed * v;

		rotAngles.x = Mathf.Clamp (rotAngles.x, 30f, 90f);
		transform.rotation = Quaternion.Euler (rotAngles);
	}
}
