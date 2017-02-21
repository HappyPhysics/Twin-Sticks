using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerText : MonoBehaviour {
	Text[] Texts;

	Speedometer speedometer;
	// Use this for initialization
	void Start () {
		Texts = GetComponentsInChildren<Text> ();
		speedometer = FindObjectOfType<Speedometer> ();

	}
	
	// Update is called once per frame
	void Update () {
		Texts [0].text = speedometer.speed.ToString ("00");
		Texts [1].text = speedometer.AccelerationMag.ToString ("00.#");

	}
}
