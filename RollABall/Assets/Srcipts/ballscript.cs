using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour {

    public float appliedForce = 1;
    public GameObject plane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("UP");
            // transform.position = transform.position + new Vector3(0,0,1);
            // GetComponent<Rigidbody>().AddForce(0, 0, appliedForce);
            plane.GetComponent<Transform>().eulerAngles += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("DOWN");
            //  transform.position = transform.position - new Vector3(0, 0, 1);
            //GetComponent<Rigidbody>().AddForce(0, 0, -appliedForce);
            plane.GetComponent<Transform>().eulerAngles += new Vector3(1, 0, 0);

        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("LEFT");
            // transform.position = transform.position - new Vector3(1, 0, 0);
            //GetComponent<Rigidbody>().AddForce(-appliedForce, 0, 0);
            plane.GetComponent<Transform>().eulerAngles += new Vector3(0, 0, -1);

        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("RIGHT");
            //GetComponent<Rigidbody>().AddForce(appliedForce, 0, 0);
            plane.GetComponent<Transform>().eulerAngles += new Vector3(0, 0, 1);
            //transform.position = transform.position + new Vector3(1, 0, 0);
        }
    }
}
