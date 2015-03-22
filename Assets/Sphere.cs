using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {
	public float speed;
	public float distance;
	Vector3 top;
	Vector3 bottom;
	bool up = true;
	// Use this for initialization
	void Start () {
		bottom = transform.position;
		top = transform.position + Vector3.up * distance;
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (up) {
			transform.position = Vector3.MoveTowards (transform.position, top, step);
		} else {
			transform.position = Vector3.MoveTowards (transform.position, bottom, step);
		}
		if (transform.position.y >= top.y) {
			up = false;
		}else if (transform.position.y <= bottom.y) {
			up = true;
		}
	}
}
