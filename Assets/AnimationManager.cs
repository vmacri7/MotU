using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class AnimationManager : MonoBehaviour {

	// Use this for initialization
	//public GameObject SelectionMenu;
	private Animation anim;

	private MLHandKeyPose[] _gestures;

	private float PlayOnlyOnce = 0;
	void Start () {
		MLHands.Start ();
		_gestures = new MLHandKeyPose[1];
		_gestures[0] = MLHandKeyPose.Finger;
		anim = gameObject.GetComponent<Animation> ();
	}

	private void OnDestroy () {
		MLHands.Stop ();
	}

	// Update is called once per frame
	void Update () {
		if (anim.isPlaying) {
			print ("Animation is already playing");
		} else if (GetGesture (MLHands.Right, MLHandKeyPose.Finger) && PlayOnlyOnce != 1) {
			anim.Play ("MenuPopUp");
			PlayOnlyOnce = 1;
		} else if (!GetGesture (MLHands.Right, MLHandKeyPose.Finger) && PlayOnlyOnce == 1) {
			PlayOnlyOnce = 0;
		}
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