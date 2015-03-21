using UnityEngine;
using System.Collections;

public class Steve : MonoBehaviour {

	public string Horizontal = "L_XAxis_1";
	public string Vertical = "L_YAxis_1";
	public string B_button = "B_1";
	public string X_button = "X_1";
	public float run_speed = 15f;
	public float run_time = 1.0f;
	public float power_up_speed = 10f;
	public GameObject Bob;

	bool running = false;
	float run_clock = 0;

	// Use this for initialization
	void Start () {
		Bob = GameObject.Find("Bob");
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = (new Vector3 (Input.GetAxis (Horizontal) - Input.GetAxis (Vertical), 0, -(Input.GetAxis (Horizontal) + Input.GetAxis (Vertical))) * run_speed);
		if (Input.GetButtonDown (B_button) & !running) {
			running = true;
			run_clock = 0;
			run_speed += power_up_speed;
		}
		if (running & run_clock < run_time) {
			run_clock += Time.deltaTime;
		} else if (running) {
			running = false;
			run_speed -= power_up_speed;
		}
		if (Input.GetButtonDown (X_button)) {
			Bob.transform.position = transform.position;
		}
	}
}
