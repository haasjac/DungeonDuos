using UnityEngine;
using System.Collections;

public class Steve : MonoBehaviour {
	
	public string Horizontal = "L_XAxis_1";
	public string Vertical = "L_YAxis_1";
	public string A_button = "A_1";
	public string B_button = "B_1";
	public string X_button = "X_1";
	public float run_speed = 15f;
	public float run_time = 1.0f;
	Vector3 ramp_vec = new Vector3 (0, 0, 0);
	public float power_up_speed = 10f;
	public GameObject Bob;
	public int damage = 50;
	public int damage_range = 10;
	bool has_key = false;
	public bool lantern = false;
	GameObject[] enemies;
	float ystart;
	Vector3 vel;
	
	bool running = false;
	float run_clock = 0;
	
	LineRenderer line;
	
	// Use this for initialization
	void Start () {
		vel = new Vector3 (1,0,1);
		transform.rotation = Quaternion.LookRotation (vel);
		ystart = transform.position.y;
		Bob = GameObject.Find("Bob");
		enemies = GameObject.FindGameObjectsWithTag("EnemyEnemy");
		
		line = GetComponent<LineRenderer>();
		line.SetPosition(0, this.gameObject.transform.position);
		line.SetPosition(1, Bob.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody>().velocity != Vector3.zero) {
			vel = GetComponent<Rigidbody>().velocity;
			transform.rotation = Quaternion.LookRotation (vel);
		}
		line.SetPosition(0, this.gameObject.transform.position);
		line.SetPosition(1, Bob.transform.position);
		if (transform.position.y != ystart) {
			Vector3 temp = transform.position;
			temp.y = ystart;
			transform.position = temp;
		}
		
		
		
		
		if (!lantern && !Bob.GetComponent<Bob>().swap) {
			GetComponent<Rigidbody> ().velocity = (new Vector3 (Input.GetAxis (Horizontal) - Input.GetAxis (Vertical), 0, -(Input.GetAxis (Horizontal) + Input.GetAxis (Vertical))) * run_speed) + ramp_vec;
			
			if (GetComponent<Rigidbody> ().velocity == Vector3.zero) {

		//		this.gameObject.GetComponentInChildren<Animator>().SetBool("Running", false);

				this.gameObject.GetComponentInChildren<Animator>().SetBool("Running", false);
				

			}
			else {
				this.gameObject.GetComponentInChildren<Animator>().SetBool("Running", true);
				this.gameObject.GetComponentInChildren<Animator>().CrossFade("Running",0f);
				//a.Stop("Idle");
			}
		} 
		else if (lantern) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		//dash
		if (Input.GetButtonDown (B_button) && !running) {
			this.gameObject.GetComponentInChildren<Animator>().SetBool("Dash", true);
			gameObject.GetComponent<TrailRenderer>().enabled = true;
			GameObject.Find("Dash" + Random.Range(1, 3)).GetComponent<AudioSource>().Play();
			running = true;
			run_clock = 0;
			run_speed += power_up_speed;
		}
		if (running && run_clock < run_time) {
			run_clock += Time.deltaTime;
		} else if (running) {
			gameObject.GetComponent<TrailRenderer>().enabled = false;
			running = false;
			run_speed -= power_up_speed;
			this.gameObject.GetComponentInChildren<Animator>().SetBool("Dash", false);
			this.gameObject.GetComponentInChildren<Animator>().SetBool("Attack",false);
		}
		
		
		
		
		
		if (Input.GetButtonDown (X_button) && !Bob.GetComponent<Bob>().jumping && !Bob.GetComponent<Bob>().swap) {
			//Bob.GetComponent<BoxCollider>().enabled = false;
			//Bob.transform.Translate(transform.position * (Time.deltaTime));
			//Bob.GetComponent<BoxCollider>().enabled = true;
			//float step = run_speed * Time.deltaTime;
			lantern = true;
			this.gameObject.GetComponentInChildren<Animator>().CrossFade("Lantern",0f);
			//Bob.transform.position = Vector3.MoveTowards(Bob.transform.position, transform.position, step);
			StartCoroutine(particle());
		}
		if (lantern) {
			float step = run_speed * 5 * Time.deltaTime;
			Bob.transform.position = Vector3.MoveTowards(Bob.transform.position, transform.position, step);
			if (Bob.transform.position == transform.position) {
				lantern = false;
			}
		}
		if (Input.GetButtonDown(A_button)) {
			//Debug.Log("ATTACK");
			GameObject.Find("Swoosh" + Random.Range(1, 4)).GetComponent<AudioSource>().Play();
			//this.gameObject.GetComponentInChildren<Animator>().SetBool("Attack",true);
			this.gameObject.GetComponentInChildren<Animator>().CrossFade("Attack",0f);
			foreach (GameObject item in enemies)
			{
				if (item != null) {
					Vector3 direction = item.transform.position - this.transform.position;
					float distA = direction.magnitude;
					direction = direction / distA;
					distA = Vector3.Distance(item.transform.position, this.transform.position);
					//Debug.Log(distA);
					if (distA < damage_range) {
						//Debug.Log(item);
						if (Mathf.Abs(Vector3.Angle(vel, direction)) <= 70)
						{
							item.GetComponent<enemyHealth>().changeHealth((-1 * damage));
							//enemies = GameObject.FindGameObjectsWithTag("EnemyEnemy");
						}
					}
				}
			}
			
		}//else 
	}
	
	IEnumerator particle()
	{
		GameObject.Find("Slide").GetComponent<AudioSource>().Play();
		GetComponent<LineRenderer>().enabled = true;
		yield return new WaitForSeconds(0.5f);
		GetComponent<LineRenderer>().enabled = false;
		
	}
	
	void OnTriggerEnter(Collider collision) {
		//Debug.Log ("hit");
		if (collision.gameObject.tag == "Ramp") {
			//Debug.Log ("hit player");
			//ramp_object = collision.gameObject;
			ramp_vec = collision.GetComponent<Push_block>().push * collision.GetComponent<Push_block>().push_force;
			//ramp = true;
		}
		if (collision.gameObject.tag == "Key" && !has_key) {
			has_key = true;
			Destroy(collision.gameObject);
		}
		
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "locked_door" && has_key) {
			has_key = false;
			collision.gameObject.GetComponent<Gate>().dead = true;
			//Destroy(collision.gameObject);
		}
		
	}
	
	
	void OnTriggerExit(Collider collision) {
		//Debug.Log ("hit");
		if (collision.gameObject.tag == "Ramp") {
			//Debug.Log ("hit player");
			ramp_vec = new Vector3 (0, 0, 0);
			//ramp = false;
		}
		
	}
	
}
