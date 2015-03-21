using UnityEngine;
using System.Collections;

public class Room_S : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "a")print ("tag is a");
		print ("Someone is in the room\n");
	}

     
}
