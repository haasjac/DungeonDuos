using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public string Next_Level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit")) {
			Application.LoadLevel(Next_Level);
		}
	}
}
