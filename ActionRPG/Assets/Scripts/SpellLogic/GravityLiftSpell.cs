using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLiftSpell : MonoBehaviour {

    //array of enemies in area
    private Collider[] thingsInArea = new Collider[0];
    private List<GameObject> enemies = new List<GameObject>();

    [Header("Spell vars")]
    public float effectRadius = 4.0f; //the aoe radius
    public float raiseForce = 1.0f; //amount of force applied to raise target
    public float dropForce = 10.0f; //amount of force applied on decent
    public float spellLifetime = 5.0f;
    public float disableTime = 5.0f; //sent to enemy, disables for this time
    public float dropTime = 4.0f; //time that the enemy is dropped

    private float startTime = 0.0f;

    //control bools
    private bool hasRaised = false;
    private bool hasDropped = false;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasDropped && Time.time > startTime + spellLifetime)
        {
            Finished();
        }
        else if (hasRaised && Time.time > startTime + dropTime)
        {
            DropEnemies();
        }
        else
        {
            GetAllInArea();
            RaiseEnemies();
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

    //remove gravity and apply force to raise all enemies
    private void RaiseEnemies()
    {
        //for all enemies in list
        for (int i = 0; i < enemies.Count; i++)
        {
            //prevent enemies from moving

            //remove gravity
            enemies[i].GetComponent<Rigidbody>().useGravity = false;
            //apply upward force 
            enemies[i].GetComponent<Rigidbody>().AddForce(Vector3.up * raiseForce, ForceMode.Acceleration);
        }
        //set has raised enemies to true
        hasRaised = true;
    }

    //restore gravity and drop enemies with force
    private void DropEnemies()
    {
        //for all enemies in list
        for (int i = 0; i < enemies.Count; i++)
        {
            //restore gravity
            enemies[i].GetComponent<Rigidbody>().useGravity = true;
            //apply upward force 
            enemies[i].GetComponent<Rigidbody>().AddForce(Vector3.down * dropForce, ForceMode.Acceleration);
        }
        //set has dropped enemies to true
        hasDropped = true;
    }

    //if all done, then destroy
    private void Finished()
    {
        Destroy(gameObject);
    }
}
