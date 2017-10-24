using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackpadMovement : MonoBehaviour {

	public float moveSpeed = 10f;
	public float turnSpeed = 10f;
	private Transform cameraTransform;

	void Start () {
		cameraTransform = Camera.main.transform;
	}

	void Update () {
		var threshold = .3f;
		if (GvrControllerInput.IsTouching) {
			var pos = GvrControllerInput.TouchPosCentered;
			if (pos.magnitude > threshold) {
				var y = (pos.y - threshold) * (1f / (1f - threshold));
				var x = (pos.x - threshold) * (1f / (1f - threshold));
				var ydir = y * Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
				var xdir = x * Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
				transform.position += (ydir + xdir) * moveSpeed * Time.deltaTime;
				//transform.Rotate(Vector3.up, x * turnSpeed * Time.deltaTime);
			}
		}
	}

}
