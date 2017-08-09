using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHole : MonoBehaviour {

    //array of enemies in area
    public Collider[] thingsInArea = new Collider[0];
    public List<GameObject> enemies = new List<GameObject>();

    [Header("Spell vars")]
    public float effectRadius = 3.0f; //the aoe radius
    public float pullForce = 0.8f; //amount of force enemies are pulled by
    public float spellLifetime = 3.0f; //the lifetime of the spell
    public float disableTime = 3.0f; //sent to enemy, disables for this time
    public float damageValue = 2.0f; //set damage value <- multiply with stats?
    public float tickTime = 0.3f; //time between each tick of spell application

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
    }

    //gets all the enemies in the area <- call each tick
    private void GetAllInArea()
    {
        //get every collider in radius of effect
        thingsInArea = Physics.OverlapSphere(transform.position, effectRadius);
        //for all things captured in array
        for (int i = 0; i < thingsInArea.Length; i++)
        {
            //if it is an enemy
            if (thingsInArea[i].gameObject.CompareTag("Enemy"))
            {
                    enemies.Add(thingsInArea[i].gameObject);
            }
        }
    }

    //pulls enemies towards centre <- called each tick
    private void PullToCentre()
    {
        //for all enemies in list
        for (int i = 0; i < enemies.Count; i++)
        {
            //remove the forces on body at start of tick
            enemies[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            //get direction to centre of spell
            Vector3 toCentre = transform.position - enemies[i].transform.position;
            //apply force to the body
            enemies[i].GetComponent<Rigidbody>().AddForce(toCentre * pullForce, ForceMode.Impulse);
        }
    }

    //spell logic
    private void SpellSequence()
    {
        GetAllInArea();
        PullToCentre();
        enemies.Clear();
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
        Gizmos.DrawSphere(transform.position, effectRadius);
    }
}
