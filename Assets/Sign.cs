using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sign : MonoBehaviour {
	GameObject canvas;
	//public string TextArea (string text, none);
	public int Room;
	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("Canvas/Dialouge");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider collision) {
		if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") {
			//Time.timeScale = 0;
			if (Room == 0) {
				canvas.GetComponent<Dialouge_script>().mytext.text = "Player 1 Press B to Charge\nPlayer 2 Press B to Leap";
			} else if (Room == 1) {
				canvas.GetComponent<Dialouge_script>().mytext.text = "Player 1 Press X to Pull Player 2 to you\nPlayer 2 Press X to Swap places";
			} else if (Room == 2) {
				canvas.GetComponent<Dialouge_script>().mytext.text = "Lookout! That guy will hurt you!\nPress A to Attack";
			} else if (Room == 3) {
				canvas.GetComponent<Dialouge_script>().mytext.text = "That key will let you open unlocked doors";
			}
			//if (Input.GetButtonDown("A_1")) {
				//Time.timeScale = 1;
			//}
			canvas.GetComponent<Image>().enabled = true;
		}
		
	}

	void OnTriggerExit(Collider collision) {
		if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") {
			canvas.GetComponent<Dialouge_script>().mytext.text = "";
			canvas.GetComponent<Image>().enabled = false;
		}
		
	}

}
