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
    private GameObject[] Waypoints;
    private int WaypointIndex;
    public float WanderSpeed = 1.0f;

    //variable for SEEK
    public float SeekSpeed = 2.0f;
    public float RotationSpeed = 3.0f;
    private GameObject Target;
    private Transform Player;

    //Animations
    private Animator Animator;


	// Use this for initialization
	void Start () {

        NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.updatePosition = true;

        Target = GameObject.FindGameObjectWithTag("Player");
        Player = GameObject.FindGameObjectWithTag("Player").transform;      
       
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        WaypointIndex = Random.Range(0, Waypoints.Length);

        state = EnemyAIVersion2.State.WANDER;

        alive = true;

        Animator = GetComponent<Animator>();

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
    }

    void Seek()
    {
        NavAgent.speed = SeekSpeed;
        NavAgent.SetDestination(Target.transform.position);
        if(DistanceToPlayer <= 1.0f)
        {
            NavAgent.isStopped = true;
        }
        else if(DistanceToPlayer > 1.0f)
        {
            NavAgent.isStopped = false;
        }
        if(DistanceToPlayer > 10.0f)
        {
            state = EnemyAIVersion2.State.WANDER;
        }

    }

    void CheckSeekRange()
    {
        if(DistanceToPlayer < 5.0f)
        {
            state = EnemyAIVersion2.State.SEEK;
        }
        else
        {
            state = EnemyAIVersion2.State.WANDER;
        }
    }   
}
