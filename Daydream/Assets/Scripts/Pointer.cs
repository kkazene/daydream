using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    public GameObject target;
    public Vector3 hitLocation;
    GameObject controller;

    // Use this for initialization
    void Start () {
        controller = GameObject.Find("Controller");
    }

    // Update is called once per frame
    void Update () {
        controller.transform.rotation = GvrControllerInput.Orientation;

        RaycastHit hit;
        target = null;

        Color color = Color.green;

        Vector3 o = controller.transform.position;
        Vector3 d = controller.transform.forward;

        Ray ray = new Ray(o, o + d);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 8))) {
            target = hit.collider.gameObject;
            color = Color.red;
        }

        Debug.DrawLine(o, o + 1000 * d, color);

        /*
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, 100);
        */
    }
}
