using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {

	public string Horizontal = "L_XAxis_2";
	public string Vertical = "L_YAxis_2";
	public string B_button = "B_2";
	public string X_button = "X_2";
	public float leap_force = 30f;
	public float run_speed = 15f;
	public float jump_time = 0.1f;
	bool jumping = false;
	float jump_clock = 0;
	Vector3 tempjump = new Vector3(0,0,0);
	public GameObject Steve;


	// Use this for initialization
	void Start () {
		Steve = GameObject.Find ("Bob");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton (Horizontal)) {
			Debug.Log (Input.GetButton (Horizontal));
		}
		if (jumping) {
			GetComponent<Rigidbody> ().velocity = (tempjump * leap_force);
			jump_clock += Time.deltaTime;
			if (jump_clock > jump_time) {
				jumping = false;
			}
		} else {
			GetComponent<Rigidbody>().velocity =(new Vector3 (Input.GetAxis(Horizontal) - Input.GetAxis(Vertical), 0, -(Input.GetAxis(Horizontal) + Input.GetAxis(Vertical)))* run_speed);
		}

		if (Input.GetButtonDown (B_button) & (Input.GetAxis(Horizontal) != 0 | Input.GetAxis(Vertical) != 0)) {
			tempjump = new Vector3 (Input.GetAxis(Horizontal) - Input.GetAxis(Vertical), 0, -(Input.GetAxis(Horizontal) + Input.GetAxis(Vertical)));
			tempjump.Normalize();
			jumping = true;
			jump_clock = 0;
		}
		if (Input.GetButtonDown (X_button)) {
			Vector3 temppos = transform.position;
			transform.position = Steve.transform.position;
			Steve.transform.position = temppos;
		}
	}
}
