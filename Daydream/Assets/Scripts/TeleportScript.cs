using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

	public GameObject target;
	public GameObject Headset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrControllerInput.ClickButtonDown) {
			// If the Pointer currently has a non-null target
			if (PointerDot.target != null) {
				// Move the Headset at a fixed height above Pointer’s hit point.
				Headset.transform.position = PointerDot.target.position; // plus fixed height ":D"
			}
		}
	}
}
