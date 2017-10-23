using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    public GameObject target;
    public Vector3 hitLocation;

    public LineRenderer laser;

    GameObject controller;
    GameObject pointerDot;

    void Start () {
        controller = GameObject.Find("Controller");
        pointerDot = GameObject.Find("PointerDot");

        gameObject.AddComponent<LineRenderer>();
        laser = gameObject.GetComponent<LineRenderer>();
        Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
        laser.SetPositions(initLaserPositions);
        laser.SetWidth( 0.01f, 0.01f );
        laser.material = new Material(Shader.Find("Particles/Additive"));
    }

    void Update () {
        controller.transform.rotation = GvrControllerInput.Orientation;

        RaycastHit hit;
        target = null;
        Color color = Color.green;
        float length = 1e6f;

        Vector3 o = controller.transform.position;
        Vector3 d = controller.transform.forward;

        Ray ray = new Ray( o, d );
        bool isHit = Physics.Raycast( ray, out hit, Mathf.Infinity /*, (1 << 8) */ );

        if (isHit) {
            target = hit.transform.gameObject;
            hitLocation = hit.point;
            pointerDot.transform.position = hitLocation;
            color = Color.red;
            length = hit.distance;
        }

        pointerDot.SetActive( isHit );

        laser.SetColors( color, color );
        laser.SetPosition( 0, o );
        laser.SetPosition( 1, o + length * d );
    }

}
