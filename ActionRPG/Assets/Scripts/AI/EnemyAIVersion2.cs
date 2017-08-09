using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIVersion2 : MonoBehaviour {

    public NavMeshAgent NavAgent;

    public enum State
    {
        WANDER,
        SEEK
    }

    public State state;
    private bool alive;

    public float DistanceToPlayer;

    //variable for WANDER
    public GameObject[] Waypoints;
    private int WaypointIndex;
    public float WanderSpeed = 3.0f;

    //variable for SEEK
    public float SeekSpeed = 6.0f;
    public float RotationSpeed = 3.0f;
    public GameObject Target;
    public Transform Player;
    
    //variables for Sight
    public float HeightMultiplier = 1.0f;
    public float sightDistance = 10.0f;


	// Use this for initialization
	void Start () {

        NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.updatePosition = true;
       
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        WaypointIndex = Random.Range(0, Waypoints.Length);

        state = EnemyAIVersion2.State.WANDER;

        alive = true;

        StartCoroutine("FSM");
	}

    void Update()
    {
        DistanceToPlayer = Vector3.Distance(Player.position, transform.position);
        CheckSeekRange();
    }

    IEnumerator FSM() //finite state machine
    {
        while(alive)
        {
            switch (state)
            {
                case State.WANDER:
                    Wander();
                    break;
                case State.SEEK:
                    Seek();
                    break;
            }
            yield return null;
        }
    }

    void Wander()
    {
        NavAgent.speed = WanderSpeed;
        if (Vector3.Distance(this.transform.position, Waypoints[WaypointIndex].transform.position) >= 2)
        {
            NavAgent.SetDestination(Waypoints[WaypointIndex].transform.position);            
        }
        else if(Vector3.Distance(this.transform.position, Waypoints[WaypointIndex].transform.position) <= 2)
        {
            WaypointIndex = Random.Range(0, Waypoints.Length);
        }
        else
        {

        }
    }

    void Seek()
    {
        NavAgent.speed = SeekSpeed;
        NavAgent.SetDestination(Target.transform.position);
    }

    void CheckSeekRange()
    {
        if(DistanceToPlayer < 15.0f)
        {
            state = EnemyAIVersion2.State.SEEK;
        }
    }

    /*
    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * HeightMultiplier, transform.forward * sightDistance, Color.red);
        Debug.DrawRay(transform.position + Vector3.up * HeightMultiplier, (transform.forward + transform.right).normalized * sightDistance, Color.red);
        Debug.DrawRay(transform.position + Vector3.up * HeightMultiplier, (transform.forward - transform.right).normalized * sightDistance, Color.red);

        if (Physics.Raycast(transform.position + Vector3.up * HeightMultiplier, transform.forward, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                state = EnemyAIVersion2.State.SEEK;
                Target = hit.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * HeightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                state = EnemyAIVersion2.State.SEEK;
                Target = hit.collider.gameObject;
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * HeightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                state = EnemyAIVersion2.State.SEEK;
                Target = hit.collider.gameObject;
            }
        }
    }
    */
   
}
