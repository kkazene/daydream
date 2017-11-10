using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {
    public float height = 1f;

	void Start () {
	}

	void Update () {
		if (GvrControllerInput.ClickButtonDown) {
			var pointer = GameObject.Find("Controller").GetComponent<Pointer>();
			if (pointer.target != null && pointer.target.layer == 11) {
				transform.position = pointer.hitLocation + Vector3.up * height;
			}
		}
	}

}
