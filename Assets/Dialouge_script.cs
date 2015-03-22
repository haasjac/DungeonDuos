using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialouge_script : MonoBehaviour {
	public Text mytext;
	Image myimage;
	// Use this for initialization
	void Start () {
		//mytext = GetComponentsInChildren<Text> ();
		myimage = GetComponent<Image> ();
		mytext.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale > 0) {
			//mytext.text = "";
			//myimage.enabled = false;
		} else {
			mytext.text = "Press Start to Continue";
			myimage.enabled = true;
		}
	}
}
