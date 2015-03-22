using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

    public int aggroDist;
    public Transform destinationA;
    public Transform destinationB;
    private NavMeshAgent agent;

    public int damage;
    public GameObject player1;
    public GameObject player2;

    public bool hit = false;
    float distA;
    float distB;

    public AudioSource takedamage;

	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();

        destinationA = GameObject.Find("Lucian").transform;
        destinationB = GameObject.Find("Bob").transform;
        player1 = GameObject.Find("BackgroundBar");
        player2 = GameObject.Find("BackgroundBar2");
        takedamage = GameObject.Find("ArrowDamage").GetComponent<AudioSource>();

        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        distA = Vector3.Distance(destinationA.position, this.transform.position);
        distB = Vector3.Distance(destinationB.position, this.transform.position);


        if (distA < distB) {
            if (distA <= aggroDist)
            {
                agent.SetDestination(destinationA.position);
            }
        }
        else {
            if (distB <= aggroDist)
            {
                agent.SetDestination(destinationB.position);
            }
        }
        
	}

	// Update is called once per frame
	void Update () {
        distA = Vector3.Distance(destinationA.position, this.transform.position);
        distB = Vector3.Distance(destinationB.position, this.transform.position);
        if (distA <= distB) {
            if (distA <= aggroDist) {
                agent.SetDestination(destinationA.position);
            }
        }
        else {
            if (distB <= aggroDist) {
                agent.SetDestination(destinationB.position);
            }
        }
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player1") {
            GameObject.Find("BackgroundBar").GetComponent<Health>().changeHealth((-1) * damage);
        }
        else if (coll.gameObject.tag == "Player2") {
            GameObject.Find("BackgroundBar2").GetComponent<Health>().changeHealth((-1) * damage);
        }
        Vector3 dir = (coll.transform.position - transform.position).normalized;
        StartCoroutine(knockback(dir));
    }

    IEnumerator knockback(Vector3 dir)
    {
        GetComponent<Rigidbody>().velocity = (-1) * dir * 75;
        takedamage.Play();
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
