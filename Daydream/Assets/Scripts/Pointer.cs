using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

    public GameObject target;
    public Vector3 hitLocation;

    LineRenderer laser;

    GameObject pointerDot;

    void Start () {
        pointerDot = GameObject.Find("PointerDot");
        Physics.gravity = new Vector3(0f, -4f, 0f);
        gameObject.AddComponent<LineRenderer>();
        laser = gameObject.GetComponent<LineRenderer>();
        Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
        laser.SetPositions(initLaserPositions);
        laser.startWidth = 0.01f;
        laser.endWidth = 0.01f;
        laser.material = new Material(Shader.Find("Mobile/Particles/Additive"));
    }

    void Update () {
        transform.rotation = GameObject.Find("Headset").transform.rotation * GvrControllerInput.Orientation;

        RaycastHit hit;
        target = null;
        Color color = Color.green;
        float length = 1e6f;

        Vector3 o = transform.position;
        Vector3 d = transform.forward;

        Ray ray = new Ray( o, d );
        bool isHit = Physics.Raycast( ray, out hit, Mathf.Infinity /*, (1 << 10)*/ );

        if (isHit) {
            target = hit.transform.gameObject;
            hitLocation = hit.point;
            pointerDot.transform.position = hitLocation;
            switch (target.layer) {
                case 10:
                    color = Color.cyan;
                    break;
                case 11:
                    color = Color.blue;
                    break;
                default:
                    color = Color.green;
                    break;
            }
            length = hit.distance;
        }

        pointerDot.SetActive( isHit );

        laser.startColor = color;
        laser.endColor = color;
        laser.SetPosition( 0, o );
        laser.SetPosition( 1, o + length * d );
    }

}
