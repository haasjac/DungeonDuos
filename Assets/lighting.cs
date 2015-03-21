using UnityEngine;
using System.Collections;

public class lighting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("Directional Light").GetComponent<Light> ().enabled = true;
		//RenderSettings.ambientLight = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
