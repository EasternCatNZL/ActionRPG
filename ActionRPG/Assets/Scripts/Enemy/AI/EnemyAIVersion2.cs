using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIVersion2 : MonoBehaviour {

    public NavMeshAgent NavAgent;

    public enum State
    {
        WANDER,
        SEEK,
        ATTACK
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

    //variables for ATTACK
    public float AttackSpeed = 1.5f;
    public ShrimpBullet Bullet;
    public ParticleSystem MeleeParticle;
    public ParticleSystem RangedParticle;
    private float Start_Time = 0.0f;
    private float DOT_Timer;
    private bool CanDamage = false;
    public float MeleeDamage = 0.01f;
    private float DOTDamage = 0.0f;


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
                case State.ATTACK:
                    Attack();
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
        if(DistanceToPlayer < 5.0f)
        {
            state = EnemyAIVersion2.State.SEEK;
        }
    }

    void Seek()
    {
        NavAgent.speed = SeekSpeed;
        NavAgent.SetDestination(Target.transform.position);
        if(DistanceToPlayer > 4.0f)
        {
            state = EnemyAIVersion2.State.ATTACK;
        }
        if(DistanceToPlayer > 8.0f)
        {
            state = EnemyAIVersion2.State.WANDER;
        }

    }

    void Attack()
    {
        NavAgent.speed = AttackSpeed;
        NavAgent.SetDestination(Target.transform.position);

        if(DistanceToPlayer < 6.0 && DistanceToPlayer > 4.0f)
        {
            PlayRangedParticle();
        } 
        else if(DistanceToPlayer < 1.2f)
        {
            RangedParticle.Stop();
            CanDamage = true;
            NavAgent.isStopped = true;
            PlayMeleeParticle();
            
        }
        else if(DistanceToPlayer > 1.2f)
        {
            NavAgent.isStopped = false;
            CanDamage = false;
            MeleeParticle.Stop();
            ResetTimer();
        }
        else if(DistanceToPlayer > 6.5f)
        {
            RangedParticle.Stop();
            state = EnemyAIVersion2.State.SEEK;
        }
    }
    
    void PlayMeleeParticle()
    {
        if(MeleeParticle.isPlaying)
        {
            DamageOverTime();
        }
        else
        {
            MeleeParticle.Play();
        }
    }
    
    void PlayRangedParticle()
    {
        //print("in PlayRangedParticle");
        if (RangedParticle.isPlaying)
        {
            //print("in if RangedPaticle.isPlaying");
        }
        else
        {
            NavAgent.isStopped = true;
            if (RangedParticle.isStopped)
            {
                RangedParticle.Play();
                Instantiate(Bullet, transform.position + new Vector3(0.0f, 0.5f, 0.0f), transform.rotation);
                //print("fire!");
            }
        }
    }
    
    void DamageOverTime()
    {


        //Target.GetComponent<ResourceManagement>().DamageHealth(DOTDamage);
    }
    
    void ResetTimer()
    {
        Start_Time = 0.0f;
    }   
}
