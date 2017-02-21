using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public bool isRecording = true;

	// Use this for initialization
	void Start () {
		PlayerPrefsManager.UnlockLevel (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			isRecording = false;
			PlayerPrefsManager.UnlockLevel (SceneManager.GetActiveScene ().buildIndex + 1);
		} else {
			isRecording = true;
		}

		if (CrossPlatformInputManager.GetButton ("Fire2")) {
			NextLevel ();
		} 
	}

	void NextLevel (){
		int level = SceneManager.GetActiveScene ().buildIndex + 1;
		if (PlayerPrefsManager.IsLevelUnlocked(level)) {
			SceneManager.LoadScene (level);
		} else {
			Debug.Log ("Level locked");
		}
		
	}
}
