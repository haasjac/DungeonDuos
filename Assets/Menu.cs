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
            GameObject.Find("Stinger").GetComponent<AudioSource>().Play();

            AutoFade.LoadLevel(Next_Level, 0.25f, 0.25f, Color.black);
			//Application.LoadLevel(Next_Level);
		}
	}
}
