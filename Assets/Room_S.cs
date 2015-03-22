using UnityEngine;
using System.Collections;

public class Room_S : MonoBehaviour {
	public GameObject Wall1;
	public GameObject Wall2;
	public Material Trans;
	public Material Opaque;

	public GameObject Torch1;
	public GameObject Torch2;
	public GameObject Torch3;
	public GameObject Torch4;

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Player1" || other.tag == "Player2") {
			GameObject.Find("Transition").GetComponent<AudioSource>().Play();
			Wall1.GetComponent<Renderer> ().material = Trans; 
			Wall2.GetComponent<Renderer> ().material = Trans; 
			Torch1.GetComponentInChildren<ParticleSystem>().Play();
			Torch2.GetComponentInChildren<ParticleSystem>().Play();
			Torch3.GetComponentInChildren<ParticleSystem>().Play();
			Torch4.GetComponentInChildren<ParticleSystem>().Play();
		}   
	}
	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player1" || other.tag == "Player2") {
			Wall1.GetComponent<Renderer> ().material = Opaque; 
			Wall2.GetComponent<Renderer> ().material = Opaque;
			Torch1.GetComponentInChildren<ParticleSystem>().Stop();
			Torch2.GetComponentInChildren<ParticleSystem>().Stop();
			Torch3.GetComponentInChildren<ParticleSystem>().Stop();
			Torch4.GetComponentInChildren<ParticleSystem>().Stop();
		}
	}
}
