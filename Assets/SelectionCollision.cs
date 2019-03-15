using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class SelectionCollision : MonoBehaviour {

	// Use this for initialization
	public TextMesh SelectorText;

	private string CurrentObject = "Selector";

	private void OnTriggerEnter (Collider col) {
		print (col.name);
		CurrentObject = col.name;
		SelectorText.text = CurrentObject;
	}
}