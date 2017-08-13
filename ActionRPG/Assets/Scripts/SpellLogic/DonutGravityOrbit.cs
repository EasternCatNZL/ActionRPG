using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutGravityOrbit : MonoBehaviour {

    //array of enemies in area
    public Collider[] enemiesInSphere = new Collider[0];
    public List<GameObject> enemies = new List<GameObject>();

    [Header("Spell vars")]
    public float outerRadius = 5.0f; //length of radius
    public float innerRadius = 3.0f; //length of inner circle radius
    public float spellLifetime = 4.0f; //lifetime of the spell
    public float resourceCost = 2.0f; //cost of using this spell
    public float damageValue = 0.2f; //amount of damage spell does each tick <- multiply with stats
    public float slowAmount = 0.8f; //% amount enemy move speed is decreased by, incremented each tick
    public float tickTime = 0.3f; //time between each tick of spell application
    public float slowTime = 0.5f; //amount of time slow lasts for, reapplied each tick

    private float startTime = 0.0f; //time this spell started, for timing
    private float lastTickTime = 0.0f; //time of last tick

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > startTime + spellLifetime)
        {
            Finished();
        }
        else if (Time.time > lastTickTime + tickTime)
        {
            SpellSequence();
        }
        //SpellSequence();
	}

    //get all enemies in the aoe, and then remove all within inner circle
    private void GetAllInArea()
    {
        //get every collider in whole radius
        enemiesInSphere = Physics.OverlapSphere(transform.position, outerRadius);
        //for all things captured in array
        for (int i = 0; i < enemiesInSphere.Length; i++)
        {
            //if it is an enemy, add to enemy list
            if (enemiesInSphere[i].gameObject.CompareTag("Enemy"))
            {
                enemies.Add(enemiesInSphere[i].gameObject);
            }
        }
        //get every collider in inner radius
        enemiesInSphere = Physics.OverlapSphere(transform.position, innerRadius);

        //for all things captured in array
        for (int i = 0; i < enemiesInSphere.Length; i++)
        {
            //if it exists in list, remove it
            if (enemies.Contains(enemiesInSphere[i].gameObject))
            {
                enemies.Remove(enemiesInSphere[i].gameObject);
            }
        }
    }

    //apply effects of spell
    private void ApplySpell()
    {
        //for each enemy
        for (int i = 0; i < enemies.Count; i++)
        {
            //renew the slow timer
            //apply damage
            enemies[i].GetComponent<EnemyResourceBehaviour>().DecreaseHealth(damageValue);
            //apply slow
        }

        //clear list once done
        enemies.Clear();
    }

    //spell logic
    private void SpellSequence()
    {
        GetAllInArea();
        ApplySpell();
        lastTickTime = Time.time;
    }

    //if done, destroy self
    private void Finished()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        //gizmo debug of outer sphere
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, outerRadius);
        //gizmo debug of inner sphere
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, innerRadius);
    }
}
