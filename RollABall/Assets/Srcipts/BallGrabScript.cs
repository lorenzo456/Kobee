using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrabScript : MonoBehaviour {

     Vector3 screenPoint;
     Vector3 scanPos;
     Vector3 offset;

    public float force;
    public float depth;
    public float angle = 30;

    Vector3 initialPosition;

	// Use this for initialization
	void Start () {
        initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -10)
        {
            initializeBall();
        }
	}

    void initializeBall()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = initialPosition; 
    }

    void OnMouseDown()
    {
        //Debug.Log("TOUCHED THE BALL");
        //print("TOUCHED THE BALL");
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);     
    }


    void OnMouseDrag()
    {
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;        
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().useGravity = true;
        Vector3 dir = Quaternion.AngleAxis(30, Vector3.forward) * Vector3.forward;
        GetComponent<Rigidbody>().AddForce( dir * force);
        Debug.Log("MOUSEUP");
    }
}
