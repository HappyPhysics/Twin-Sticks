using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {
	[SerializeField] private float ReplayTime = 10; // total length of saved replay in seconds

	private MyKeyFrame[] replay;

	private const int ReplayFrameRate = 24; // frames per second
	private int numKeyFrames; // total number of saved frames.
	private float saveTime; // records the time of the last record/replay.
	private int frameCount = 0; // number of frames recorded/played; position on replay array.
	private int saveFrameCount = 0; // save the current count when going to playback mode
	private bool recording = true;

	private Rigidbody rigidBody;

	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
		rigidBody = GetComponent<Rigidbody>();

		numKeyFrames = (int) ReplayTime * ReplayFrameRate;
		replay = new MyKeyFrame[numKeyFrames];

		Record ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - saveTime) > 1.0f / ReplayFrameRate) {
			frameCount++;
			togglePlayback ();
		}
	}

	void playBack() {
		

		int frameNum = frameCount % numKeyFrames;
		transform.position = replay [frameNum].position;
		transform.rotation = replay [frameNum].rotation;

		saveTime = Time.time;
		//Debug.Log ("Reading Frame: " + frameNum);
	}

	void Record() {
		rigidBody.isKinematic = false;
		int frameNum = frameCount % numKeyFrames;
		replay[frameNum] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
		saveTime = Time.time;
		//Debug.Log ("writing frame: " + frameNum);
	}

	void togglePlayback() {
		if (recording) {
			Record ();
		} else {
			playBack ();
		}
		//save current spot when changing between recording and playback
		if (recording && !gameManager.isRecording) {
			rigidBody.isKinematic = true;
			saveFrameCount = frameCount;
			if (frameCount < numKeyFrames) {
				frameCount = 0;
			} 
			recording = false;

		} else if(!recording && gameManager.isRecording) {
			rigidBody.isKinematic = false;
			frameCount = saveFrameCount;
			recording = true;
			playBack ();
		}
	}
}

/// <summary>
/// A structure for storing keyframes
/// </summary>
public struct MyKeyFrame{
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation) {
		frameTime = aTime;
		position = aPosition;
		rotation = aRotation;
	}
}
