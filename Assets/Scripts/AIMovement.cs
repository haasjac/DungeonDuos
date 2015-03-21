using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

    public int aggroDist;
    public Transform destination;
    private NavMeshAgent agent;
    float dist;

	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        dist = Vector3.Distance(destination.position, this.transform.position);
        if (dist <= aggroDist) {
            agent.SetDestination(destination.position);
        }
	}

	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(destination.position, this.transform.position);
        if (dist <= aggroDist) {
            agent.SetDestination(destination.position);
        }
	}
}
