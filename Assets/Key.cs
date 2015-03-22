using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public bool dead = false;
	float speed = 20;
	float clock = 0;
	 //Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
		if (dead) {
			speed *= 10;
			clock += Time.deltaTime;
		}
		if (clock > 0.9f) {
			Destroy(this.gameObject);
		}
		
	}
}