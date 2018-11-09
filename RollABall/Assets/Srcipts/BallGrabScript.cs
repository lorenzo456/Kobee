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
	public int scores = 0;
	public bool boxTouched;

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
		boxTouched = false;
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

	void OnTriggerEnter(Collider collision)
    {
		
		Debug.Log("I HIT SOMETHING");
		Debug.Log(collision.gameObject.name);
		if(collision.gameObject.name == "Cube")
		{ boxTouched = true;
		}
		else if (collision.gameObject.name == "Floor")
		{ 
			if (boxTouched == true)
			{scores -= 1;}
			else
			{scores += 1;}
		initializeBall();
		}

    }
}
