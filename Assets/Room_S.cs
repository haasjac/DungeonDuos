using UnityEngine;
using System.Collections;

public class Room_S : MonoBehaviour {
	public GameObject Wall1;
	public GameObject Wall2;
	public Material Trans;
	public Material Opaque;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Wall1.GetComponent<Renderer> ().material = Trans; 
			Wall2.GetComponent<Renderer> ().material = Trans; 
		}   
	}
	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") {
			Wall1.GetComponent<Renderer> ().material = Opaque; 
			Wall2.GetComponent<Renderer> ().material = Opaque; 
		}
	}
}
