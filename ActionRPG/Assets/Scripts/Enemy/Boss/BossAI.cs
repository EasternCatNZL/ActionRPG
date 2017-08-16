using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyResourceBehaviour))]
public class BossAI : MonoBehaviour {

    private float PI = 3.1415f;

    public GameObject Player;
    public GameObject Opening;

    [Header("Attack Properties")]
   
    [Header("Random Attack Properties")]
    public GameObject bomb = null;
    public float AttackCooldown = 1.0f;
    public float castRadius = 5.0f;
    public float attackRadius = 1.0f;
    public float attackDamage = 2.0f;
    public float attackDelay = 2.0f;
    private bool CanRandAttack = true;
    [Header("Pullin' Attack Properties")]
    public float PullCooldown = 5.0f;
    public float pullStrength = 4.0f;
    public GameObject boulder = null;
    public float boulderSpawnRadius = 1.0f;
    public float boulderSpeed = 50.0f;
    private bool CanPull = false;

    private EnemyResourceBehaviour HealthManager;

    private float lastAttackTime = 0f;
    private float lastPullTime = 0f;

    private Vector3 lastAttackPos = Vector3.zero;

    private void Start()
    {
        CanRandAttack = true;
        if(GetComponent<EnemyResourceBehaviour>())
        {
            HealthManager = GetComponent<EnemyResourceBehaviour>();
        }
        lastAttackTime = Time.time;
    }

    private void OnDestroy()
    {
        Opening.GetComponent<Interactable>().Activate();
    }

    private void Update()
    {
        if (!CanPull && HealthManager.GetHealthPercentage() < 0.5f)
        {
            CanPull = true;
        }
        if (Time.time - lastAttackTime > AttackCooldown)
        {
            if (CanRandAttack) AttackRandomArea();
            lastAttackTime = Time.time;
        }
        if (Time.time - lastPullTime > PullCooldown)
        {
            if (CanPull) ConsumeAttack();
            lastPullTime = Time.time;
            PullCooldown = Random.Range(3, 6);
        }
    }

    private void AttackRandomArea()
    {
        Vector3 RandomPos = new Vector3(
            Mathf.Sin(Random.Range(0f,360f) * PI / 180f) * (Random.Range(0f, castRadius * 2) - castRadius),
            0f,
            Mathf.Cos(Random.Range(0f,360f) * PI / 180f) * (Random.Range(0f, castRadius * 2) - castRadius)
            );
        lastAttackPos = transform.position + RandomPos;
        StartCoroutine(DelayAttack(lastAttackPos));
        //print(Random.Range(0f, castRadius * 2) - castRadius);
        //print(RandomPos.ToString());
        //print(lastAttackPos);
    }

    private IEnumerator DelayAttack(Vector3 _AttackPos)
    {
        yield return new WaitForSeconds(attackDelay);
        Instantiate(bomb, _AttackPos + new Vector3(0f, 2f, 0f), Random.rotation);
        //if(Vector3.Distance(_AttackPos, Player.transform.position) < attackRadius)
        //{
        //    Player.GetComponent<ResourceManagement>().DamageHealth(attackDamage);
        //}
    }

    private void ConsumeAttack()
    {
        //Pull Player In
        Vector3 Direction = transform.position - Player.transform.position;
        Direction.Normalize();
        Player.GetComponent<Rigidbody>().AddForce(Direction * pullStrength, ForceMode.Impulse);
        //Create Boulder
        //GameObject temp = null;
        //int r = Random.Range(0, 360);
        //Vector3 SpawnPos = new Vector3(Mathf.Sin(r * PI / 180f) * boulderSpawnRadius, 0.0f, Mathf.Cos(r * PI / 180f) * boulderSpawnRadius) + transform.position;
        //temp = Instantiate(boulder, SpawnPos, Quaternion.identity);
        //Direction = transform.position - SpawnPos;
        //Direction.Normalize();
        //temp.GetComponent<Rigidbody>().AddForce(Direction * boulderSpeed, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = this.transform.position;

        Gizmos.color = Color.red;

        for (int i = 0, r = 360; i <= 10; ++i, r -= 360 / 10)
        {
            Gizmos.DrawSphere(new Vector3(Mathf.Sin(r * PI / 180f) * castRadius, 0.0f, Mathf.Cos(r * PI / 180f) * castRadius) + pos , 0.1f);
        }

        Gizmos.color = Color.magenta;

        Gizmos.DrawSphere(lastAttackPos, 0.2f);
    }

}
