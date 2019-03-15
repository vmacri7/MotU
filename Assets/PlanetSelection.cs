using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class PlanetSelection : MonoBehaviour {

	//public enum HandPoses { Ok, Finger, Thumb, OpenHandBack, Fist, NoPose };
	//public HandPoses pose = HandPoses.NoPose;
	public Vector3[] pos;
	public GameObject sphereIndex;

	private MLHandKeyPose[] _gestures;
	private bool FingerDetected = false;

	private void Awake () {
		MLHands.Start ();
		_gestures = new MLHandKeyPose[1];
		_gestures[0] = MLHandKeyPose.Finger;

		MLHands.KeyPoseManager.EnableKeyPoses (_gestures, true, false);
		pos = new Vector3[3];

		//sphereIndex = GameObject.Find("SelectionMenu");
	}
	private void OnDestroy () {
		MLHands.Stop ();
	}

	private void Update () {
		if (GetGesture (MLHands.Right, MLHandKeyPose.Finger)) {
			FingerDetected = true;
		} else if (!GetGesture (MLHands.Right, MLHandKeyPose.Finger)){
			FingerDetected = false;
		}
			
		if (FingerDetected == true) {
				ShowPoints ();
				//sphereIndex.SetActive = true;
				//print("active");
			}
		else {
			//sphereIndex.SetActive = false;
			print("inactive");
		}
// Makes the menu face the player at all times
		sphereIndex.transform.rotation = transform.rotation;
	}

	private void ShowPoints () {

		print ("active");

// Places the menu on the finger of the player
		pos[0] = MLHands.Right.Index.KeyPoints[0].Position;

		sphereIndex.transform.position = pos[0];

	}

	private bool GetGesture (MLHand hand, MLHandKeyPose type) {
		if (hand != null) {
			if (hand.KeyPose == type) {
				if (hand.KeyPoseConfidence > 0.9f) {
					return true;
				}
			}
		}
		return false;
	}

}