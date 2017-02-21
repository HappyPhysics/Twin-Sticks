using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
	private const string LEVEL_KEY = "level_unlocked_";

	public static void UnlockLevel(int level) {
		if (level < SceneManager.sceneCountInBuildSettings) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); //use 1 for true
		} else {
			Debug.Log ("trying to unlock level not in build settings. No Level with index: " +  level);
		}
	}
	
	public static bool IsLevelUnlocked(int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = levelValue == 1;

		if (level < SceneManager.sceneCountInBuildSettings) {
			return isLevelUnlocked;
		} else {
			Debug.Log ("level not in build settings.");
			return false;
		}
	}
}
