using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackpadMovement : MonoBehaviour {

	public float moveSpeed = 50f;
	public float turnSpeed = 180f;
	private Transform cameraTransform;

	void Start () {
		cameraTransform = Camera.main.transform;
	}

	void Update () {
		var threshold = .4f;
		if (GvrControllerInput.IsTouching) {
			var pos = GvrControllerInput.TouchPosCentered;
			if (Mathf.Abs(pos.y) > threshold) {
				var y = pos.y - Mathf.Sign(pos.y) * threshold;
				var ydir = y * Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
				transform.position += ydir * moveSpeed * Time.deltaTime;
			}
			if (Mathf.Abs(pos.x) > threshold) {
				var x = pos.x - Mathf.Sign(pos.x) * threshold;
				transform.Rotate(Vector3.up, x * turnSpeed * Time.deltaTime);
				// strafe
				var xdir = -x * Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
				transform.position += xdir * moveSpeed * Time.deltaTime;
			}
		}
	}

}
