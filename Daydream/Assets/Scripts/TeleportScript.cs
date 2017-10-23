using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

	GameObject headset;

	void Start () {
        headset = GameObject.Find("Headset");
	}

	void Update () {
		if (GvrControllerInput.ClickButtonDown) {
			var pointer = GameObject.Find("Controller").GetComponent<Pointer>();
			if (pointer.target != null) {
				headset.transform.position = pointer.hitLocation + Vector3.up * 1f;
			}
		}
	}

}
