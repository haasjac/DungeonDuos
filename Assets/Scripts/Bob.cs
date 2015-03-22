using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {

	public string Horizontal = "L_XAxis_2";
	public string Vertical = "L_YAxis_2";
	public string A_button = "A_2";
	public string B_button = "B_2";
	public string X_button = "X_2";
	public float leap_force = 30f;
	public float run_speed = 15f;
	public float jump_time = 0.1f;
	Vector3 ramp_vec = new Vector3 (0, 0, 0);
	public bool jumping = false;
	public int damage = 50;
	public int damage_range = 10;
	//bool ramp = false;
	float jump_clock = 0;
	Vector3 tempjump = new Vector3(0,0,0);
	public GameObject Steve;
	bool has_key = false;
	public bool swap = false;
	Vector3 bobpos;
	Vector3 stevepos;
	GameObject[] enemies;
	float ystart;
    Vector3 vel;

    public GameObject sParticles;
    public GameObject bParticles;


	// Use this for initialization
	void Start () {
        vel = new Vector3(1, 0, 1);
        transform.rotation = Quaternion.LookRotation(vel);
		ystart = transform.position.y;
		Steve = GameObject.Find ("Lucian");
		enemies = GameObject.FindGameObjectsWithTag("EnemyEnemy");
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody> ().velocity != Vector3.zero) {
			vel = GetComponent<Rigidbody> ().velocity;
			if(!jumping) {
				this.gameObject.GetComponentInChildren<Animator>().SetBool("Run", true);
				this.gameObject.GetComponentInChildren<Animator>().CrossFade("Run",0f);
			}
			transform.rotation = Quaternion.LookRotation (vel);
		}
		else {
			this.gameObject.GetComponentInChildren<Animator>().SetBool("Run", false);
			//this.gameObject.GetComponentInChildren<Animator>().CrossFade("Idle",0f);
		}
		if (Input.GetButton (Horizontal)) {
			Debug.Log (Input.GetButton (Horizontal));
		}
		if (jumping) {
			GetComponent<Rigidbody> ().velocity = (tempjump * leap_force) + ramp_vec;
			jump_clock += Time.deltaTime;
			if (jump_clock > jump_time) {
				jumping = false;
				Vector3 pos = transform.position - new Vector3 (0, 2, 0);
				transform.position = pos;
			}

		} else if (!Steve.GetComponent<Steve>().lantern && !swap){

			//this.gameObject.GetComponentInChildren<Animator>().CrossFade("Run",0f);
			GetComponent<Rigidbody>().velocity =(new Vector3 (Input.GetAxis(Horizontal) - Input.GetAxis(Vertical), 0, -(Input.GetAxis(Horizontal) + Input.GetAxis(Vertical)))* run_speed) + ramp_vec;
		}

		if (!jumping) {
			if (transform.position.y != ystart) {
				Vector3 temp = transform.position;
				temp.y = ystart;
				transform.position = temp;
			}
		}

		if (Input.GetButtonDown (B_button) && !jumping && (Input.GetAxis(Horizontal) != 0 || Input.GetAxis(Vertical) != 0)) {
			this.gameObject.GetComponentInChildren<Animator>().CrossFade("Leap",0f);
			tempjump = new Vector3 (Input.GetAxis(Horizontal) - Input.GetAxis(Vertical), 0, -(Input.GetAxis(Horizontal) + Input.GetAxis(Vertical)));
			tempjump.Normalize();
			jumping = true;
			jump_clock = 0;
			Vector3 pos = transform.position + new Vector3 (0, 2, 0);
			transform.position = pos;
		}
		if (Input.GetButtonDown (X_button)&& !jumping && !Steve.GetComponent<Steve>().lantern) {
			this.gameObject.GetComponentInChildren<Animator>().CrossFade("Swap",0f);
            StartCoroutine(particle());
			swap = true;
			bobpos = transform.position;
			stevepos = Steve.transform.position;
			//Vector3 temppos = transform.position;
			//transform.position = Steve.transform.position;
			//Steve.transform.position = temppos;

		}

		if (Input.GetButtonDown(A_button)) {
			//Debug.Log("ATTACK");
            GameObject.Find("Swoosh" + Random.Range(1, 4)).GetComponent<AudioSource>().Play();
			this.gameObject.GetComponentInChildren<Animator>().CrossFade("Attack",0f);
			//print ("ATAK");
			foreach (GameObject item in enemies) {
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
		}

		if (swap) {
			float step = run_speed * 5 * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, stevepos, step);
			Steve.transform.position = Vector3.MoveTowards(Steve.transform.position, bobpos, step);
			if (transform.position == stevepos && Steve.transform.position == bobpos) {
				swap = false;
			}
		}

	}

    IEnumerator particle()
    {
        GameObject.Find("Puff").GetComponent<AudioSource>().Play();
        sParticles.SetActive(true);
        bParticles.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        sParticles.SetActive(false);
        bParticles.SetActive(false);
    }

	void OnTriggerEnter(Collider collision) {
		//Debug.Log ("hit");
		if (collision.gameObject.tag == "Ramp") {
			//Debug.Log ("hit player");
			//ramp_object = collision.gameObject;
			ramp_vec = collision.GetComponent<Push_block>().push * collision.GetComponent<Push_block>().push_force;
			//ramp = true;
		}
		if (collision.gameObject.tag == "Key"  && !has_key) {
			has_key = true;
			collision.gameObject.GetComponent<Key>().dead = true;
			//Destroy(collision.gameObject);
		}
		
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "locked_door" && has_key && !collision.gameObject.GetComponent<Gate>().dead) {
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
