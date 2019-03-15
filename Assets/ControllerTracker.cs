using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ControllerTracker : MonoBehaviour {
	public MLInputController controller;

//	public Collider SelectorCollider;
//	public Collider EarthCollider;
	private GameObject control;
	void Start () {
		MLInput.Start ();
		controller = MLInput.GetController (MLInput.Hand.Left);
		control = GameObject.Find ("ControllerEmpty");
	}

	private void OnDestroy () {
		MLInput.Stop ();
	}
	// Update is called once per frame
	void Update () {
		control.transform.position = controller.Position;
		control.transform.rotation = controller.Orientation;
	}
}