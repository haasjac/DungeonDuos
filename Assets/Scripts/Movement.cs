using UnityEngine;
using System.Collections;

// Camera Controller
// Revision 2
// Allows the camera to move left, right, up and down along a fixed axis.
// Attach to a camera GameObject (e.g MainCamera) for functionality.

public class Movement : MonoBehaviour {

	//public string Horizontal = "L_XAxis_1";
	//public string Vertical = "L_YAxis_1";

	// How fast the camera moves
	//public float cameraVelocity = 0.1f;
	GameObject bob;
	GameObject steve;

	
	// Use this for initialization
	void Start () {
		
		// Set the initial position of the camera.
		// Right now we don't actually need to set up any other variables as
		// we will start with the initial position of the camera in the scene editor
		// If you want to create cameras dynamically this will be the place to
		// set the initial transform.positiom.x/y/z
		bob = GameObject.Find ("Bob");
		steve = GameObject.Find ("Lucian");
	}

	//void FixedUpdate() {
		//GetComponent<Rigidbody>().AddForce((new Vector3 (1, 0, -1) * cameraVelocity)* Input.GetAxis(Vertical));
	//}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = new Vector3 ((bob.transform.position.x + steve.transform.position.x) / 2.0f, transform.position.y, (bob.transform.position.z + steve.transform.position.z) / 2.0f);  
		pos += new Vector3 (1, 0, 1) * -10;
		transform.position = pos;
		// Left
		//if(Input.GetAxis(Horizontal) < 0)
		//{
		//if (Mathf.Abs(Input.GetAxis(Horizontal)) > .75)
		//GetComponent<Rigidbody>().velocity =(new Vector3 (Input.GetAxis(Horizontal) - Input.GetAxis(Vertical), 0, -(Input.GetAxis(Horizontal) + Input.GetAxis(Vertical)))* cameraVelocity);
		//rigidbody.AddForce(Vector3.right);
		//}
		// Right
		//if(Input.GetAxis(Horizontal) > 0)
		//{
		//	transform.Translate((new Vector3 (1, 0, -1) * cameraVelocity) * Time.deltaTime);
		//}
		// Up
		//if(Input.GetAxis(Vertical) > 0)
		//{
		//Debug.Log (Mathf.Abs (Input.GetAxis (Vertical)));
		//if (Mathf.Abs(Input.GetAxis(Vertical)) > .75)
		//GetComponent<Rigidbody>().velocity((new Vector3 (-1, 0, -1) * cameraVelocity* Input.GetAxis(Vertical)));
		//}
		// Down
		//if(Input.GetAxis(Vertical) < 0)
		//{
			//transform.Translate((new Vector3 (-1, 0, -1) * cameraVelocity) * Time.deltaTime);
		//}
	}
}