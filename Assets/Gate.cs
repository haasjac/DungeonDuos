using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
	public bool dead = false;
	Vector3 temp;
	// Use this for initialization
	void Start () {
		temp = transform.position - (Vector3.up * 7);
	}
	
	// Update is called once per frame
	void Update () {
		if (dead) {
			float step = 5 * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, temp, step);
		}
		if (transform.position == temp) {
			Destroy(this.gameObject);
		}

	}
}
