using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

	void Start () {
	}

	void Update () {
		if (GvrControllerInput.ClickButtonDown) {
			var pointer = GameObject.Find("Controller").GetComponent<Pointer>();
			if (pointer.target != null) {
				transform.position = pointer.hitLocation + Vector3.up * 1f;
			}
		}
	}

}
