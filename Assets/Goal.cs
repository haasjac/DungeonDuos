using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public string Next_Level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision) {
		//Debug.Log ("hit");
		if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") {
			AutoFade.LoadLevel(Next_Level, 0.25f, 0.25f, Color.black);
			//Application.LoadLevel(Next_Level);
		}
		
	}

}
