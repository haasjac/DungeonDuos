using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.FindChild ("Backbar").GetComponent<enemyHealth> ().currentHealth <= 0) {
			//print ("dead");
			Destroy(this.gameObject);
		}
	}
}
