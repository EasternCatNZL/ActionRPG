using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawIn : MonoBehaviour {

    //array of enemies in area
    private Collider[] thingsInArea = new Collider[0];
    private List<GameObject> enemies = new List<GameObject>();

    [Header("Spell vars")]
    [Tooltip("radius of spell")]
    public float effectRadius = 4.0f;
    [Tooltip("lifetime of the spell")]
    public float spellLifetime = 2.0f;
    [Tooltip("Time damage is applied into spell")]
    public float damageTime = 1.0f;
    [Tooltip("Amount of damage dealt")]
    public float damageValue = 2.0f;
    [Tooltip("Resource cost value")]
    public float resourceCost = 1.0f;
    [Tooltip("The scale applied to inward pull force")]
    public float pullForce = 1.2f;
    [Tooltip("Upward alteration to level out with units")]
    public float upwardPull = 0.5f;
    //[Tooltip("Accompanying particle effect")]
    //public GameObject drawInParticle;

    private float startTime = 0.0f; //time this spell started, for timing

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        //Attack();
        SpellStart();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > startTime + spellLifetime)
        {
            Finished();
        }
        else if (Time.time > startTime + damageTime)
        {
            DamageEnemies();
        }
	}

    //finds all enemies in area of effect
    private void GetAllInArea()
    {
        //get every collider in radius of effect
        thingsInArea = Physics.OverlapSphere(transform.position, effectRadius);
        //for all things captured in array
        for (int i = 0; i < thingsInArea.Length; i++)
        {
            //if it is an enemy, add to enemy list
            if (thingsInArea[i].gameObject.CompareTag("Enemy"))
            {
                enemies.Add(thingsInArea[i].gameObject);
            }
        }
    }

    //apply force and draw in enemies
    private void PullIn()
    {
        //for all enemies in list
        for (int i = 0; i < enemies.Count; i++)
        {
            //get a directional vector towards center of circle and slightly up
            Vector3 slightlyUp = new Vector3(transform.position.x, transform.position.y + upwardPull, transform.position.z);
            Vector3 directionToPull = slightlyUp - enemies[i].transform.position;
            //apply a force to the body
            enemies[i].GetComponent<Rigidbody>().AddForce(directionToPull * pullForce, ForceMode.Impulse);
        }
    }

    //calls opening spell effects
    private void SpellStart()
    {
        GetAllInArea();
        PullIn();
    }

    //apply damage, called at set time
    private void DamageEnemies()
    {
        //for all enemies in list
        for (int i = 0; i < enemies.Count; i++)
        {
            //apply damage
            enemies[i].GetComponent<EnemyResourceBehaviour>().DecreaseHealth(damageValue);
        }
    }

    //once finished, destroy self
    private void Finished()
    {
        Destroy(gameObject);
    }

    ////attack sequence logic
    //private void Attack()
    //{
    //    //does all logic then destroys self
    //    GetAllInArea();
    //    PullIn();
    //    Destroy(gameObject);
    //}
}
