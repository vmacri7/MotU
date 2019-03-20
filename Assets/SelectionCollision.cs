using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class SelectionCollision : MonoBehaviour {

	// Use this for initialization

	public GameObject Sun;
	public GameObject SunPrefab;
	public GameObject Mercury;
	public GameObject Venus;
	public GameObject Earth;
	public GameObject Mars;
	public GameObject Jupiter;
	public GameObject Saturn;
	public GameObject Uranus;
	public GameObject Neptune;

	public TextMesh SelectorText;

	public GameObject selector;
	public GameObject placement;
	public GameObject deleter;

	private GameObject Mode; // holds either selector empty, placement empty or deletor empty

	private bool HasObject = false;

	private GameObject PlanetValueHolder;
	private MLInputController controller;
	// ControllerMode
	// 0 = Selector; 1 = Placement; 2 = Deleter
	private int ControllerMode = 0;

	private string CurrentObject = "Selector";

	private void Awake () {
		MLInput.Start ();
		controller = MLInput.GetController (MLInput.Hand.Left);
		MLInput.OnControllerButtonDown += OnButtonDown;
		Mode = GameObject.Find ("selector");
		PlanetValueHolder = GameObject.Find ("DumbbyEmptyForPlanetValueHolder");

	}
	void OnDestroy () {
		MLInput.Stop ();
		MLInput.OnControllerButtonDown -= OnButtonDown;
	}
	private void OnTriggerEnter (Collider col) {
		print (col.name);
		CurrentObject = col.name;
		SelectorText.text = CurrentObject;
	}
	private void OnTriggerExit (Collider col) {
		CurrentObject = "Selector";
		SelectorText.text = CurrentObject;
	}

	void CheckControl () {
		if (Mode == selector) {
			Mode.SetActive (false);
			ControllerMode = 1; // Placement Mode 
			CMode ();
			Mode.SetActive (true);
			PlanetValueHolder.SetActive (false);
			WhichPlanet ();
			PlanetValueHolder.SetActive (true);
			print (ControllerMode);
			HasObject = true;

		} else if (Mode == placement) {
			Mode.SetActive (false);
			print ("bumper");
			ControllerMode = 0; // Selector Mode 
			CMode ();
			Mode.SetActive (true);
			CurrentObject = "Selector";
			SelectorText.text = CurrentObject;
			print (ControllerMode);
			HasObject = false;
		}

	}
	void OnButtonDown (byte controller_id, MLInputControllerButton button) {
		if ((button == MLInputControllerButton.Bumper && ControllerMode == 1)) {
			InstantiatePlanets ();
		}
		if (button == MLInputControllerButton.HomeTap) {
			Mode.SetActive (false);
			print ("bumper");
			ControllerMode = 0; // Selector Mode 
			CMode ();
			Mode.SetActive (true);
			CurrentObject = "Selector";
			SelectorText.text = CurrentObject;
			print (ControllerMode);
			HasObject = false;
		}
	}

	// void OnButtonUp (byte controller_id, MLInputControllerButton button) {
	// 	if (button == MLInputControllerButton.HomeTap) {
	// 		Mode.SetActive (false);
	// 		print ("bumper");
	// 		ControllerMode = 0; // Selector Mode 
	// 		CMode ();
	// 		Mode.SetActive (true);
	// 		CurrentObject = "Selector";
	// 		SelectorText.text = CurrentObject;
	// 		print (ControllerMode);
	// 		HasObject = false;
	// 	}
	// }

	void CMode () {
		if (ControllerMode == 0) {
			//Mode = GameObject.Find ("ControllerEmpty.selector");
			Mode = selector;

		} else if (ControllerMode == 1) {

			//Mode = GameObject.Find ("/ContollerEmpty/placement");
			Mode = placement;
			print ("here cmode");
		}
	}

	void WhichPlanet () {
		if (CurrentObject == "Sun") {

			PlanetValueHolder = Sun;
		} else if (CurrentObject == "Mercury") {

			PlanetValueHolder = Mercury;
		} else if (CurrentObject == "Venus") {

			PlanetValueHolder = Venus;
		} else if (CurrentObject == "Earth") {

			PlanetValueHolder = Earth;
		} else if (CurrentObject == "Mars") {

			PlanetValueHolder = Mars;
		} else if (CurrentObject == "Jupiter") {

			PlanetValueHolder = Jupiter;
		} else if (CurrentObject == "Saturn") {

			PlanetValueHolder = Saturn;
		} else if (CurrentObject == "Uranus") {

			PlanetValueHolder = Uranus;
		} else if (CurrentObject == "Neptune") {

			PlanetValueHolder = Neptune;
		}

	}
	void InstantiatePlanets () {
		if (CurrentObject == "Sun") {
			GameObject spawnedSun = Instantiate (Sun) as GameObject;
			spawnedSun.transform.position = PlanetValueHolder.transform.position;
			spawnedSun.transform.rotation = PlanetValueHolder.transform.rotation;
		} else if (CurrentObject == "Mercury") {
			GameObject spawnedMercury = Instantiate (Mercury) as GameObject;
			spawnedMercury.transform.position = PlanetValueHolder.transform.position;
			spawnedMercury.transform.rotation = PlanetValueHolder.transform.rotation;
		} else if (CurrentObject == "Venus") {
			GameObject spawnedVenus = Instantiate (Venus) as GameObject;
			spawnedVenus.transform.position = PlanetValueHolder.transform.position;
			spawnedVenus.transform.rotation = PlanetValueHolder.transform.rotation;
		} else if (CurrentObject == "Earth") {
			GameObject spawnedEarth = Instantiate (Earth) as GameObject;
			spawnedEarth.transform.position = PlanetValueHolder.transform.position;
			spawnedEarth.transform.rotation = PlanetValueHolder.transform.rotation;
		} else if (CurrentObject == "Mars") {
			GameObject spawnedMars = Instantiate (Mars) as GameObject;
			spawnedMars.transform.position = PlanetValueHolder.transform.position;
			spawnedMars.transform.rotation = PlanetValueHolder.transform.rotation;
		} else if (CurrentObject == "Jupiter") {
			GameObject spawnedJupiter = Instantiate (Jupiter) as GameObject;
			spawnedJupiter.transform.position = PlanetValueHolder.transform.position;
			spawnedJupiter.transform.rotation = PlanetValueHolder.transform.rotation;
		} else if (CurrentObject == "Saturn") {
			GameObject spawnedSaturn = Instantiate (Saturn) as GameObject;
			spawnedSaturn.transform.position = PlanetValueHolder.transform.position;
			spawnedSaturn.transform.rotation = PlanetValueHolder.transform.rotation;
		} else if (CurrentObject == "Uranus") {
			GameObject spawnedUranus = Instantiate (Uranus) as GameObject;
			spawnedUranus.transform.position = PlanetValueHolder.transform.position;
			spawnedUranus.transform.rotation = PlanetValueHolder.transform.rotation;
		} else if (CurrentObject == "Neptune") {
			GameObject spawnedNeptune = Instantiate (Neptune) as GameObject;
			spawnedNeptune.transform.position = PlanetValueHolder.transform.position;
			spawnedNeptune.transform.rotation = PlanetValueHolder.transform.rotation;
		}

	}

	void Update () {
		if (controller.TriggerValue > 0.2 && CurrentObject != "Selector") {
			CheckControl ();

		}
		// if (controller.Touch1Active) {
		// 	print("HI");
		// 	Mode.SetActive (false);
		// 	print ("bumper");
		// 	ControllerMode = 0; // Selector Mode 
		// 	CMode ();
		// 	Mode.SetActive (true);
		// 	CurrentObject = "Selector";
		// 	SelectorText.text = CurrentObject;
		// 	print (ControllerMode);
		// 	HasObject = false;
		// }
	}
}