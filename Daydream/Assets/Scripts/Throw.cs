using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {
    private GameObject objectHeld = null;
    public float heldDistance = 1f;
    public float forceFactor = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GvrControllerInput.ClickButtonUp)
        {
            Vector3 currentPosition = objectHeld.transform.position;
            Vector3 lastPosition = GameObject.Find("Controller").transform.position + GameObject.Find("Controller").transform.rotation * Vector3.forward * heldDistance * 3;
            objectHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
            objectHeld.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 motionVector = new Vector3(lastPosition.x - currentPosition.x, lastPosition.y - currentPosition.y, lastPosition.z - currentPosition.z) / Time.deltaTime;
            objectHeld.GetComponent<Rigidbody>().AddForce(motionVector*forceFactor, ForceMode.Force);
            objectHeld = null;
        }
        if (GvrControllerInput.ClickButtonDown)
        {
            var pointer = GameObject.Find("Controller").GetComponent<Pointer>();
            if (pointer.target != null && pointer.target.layer == 10)
            {
                objectHeld = pointer.target;
                objectHeld.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        if(objectHeld != null) {
            objectHeld.transform.position = GameObject.Find("Controller").transform.position + GameObject.Find("Controller").transform.rotation * Vector3.forward * heldDistance;
            //lastPosition = objectHeld.transform.position;
        }
    }
}


