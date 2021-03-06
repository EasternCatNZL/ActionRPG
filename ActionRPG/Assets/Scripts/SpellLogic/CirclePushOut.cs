﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePushOut : MonoBehaviour {

    //array of enemies in area
    private Collider[] thingsInArea = new Collider[0];
    private List<GameObject> enemies = new List<GameObject>();

    [Header("Spell vars")]
    [Tooltip("Radius of spell")]
    public float effectRadius = 4.0f;
    [Tooltip("Amount of damage dealt")]
    public float damageValue = 3.0f;
    [Tooltip("lifetime of the spell")]
    public float spellLifetime = 2.0f;
    [Tooltip("Resource cost value")]
    public float resourceCost = 1.0f;
    [Tooltip("The scale applied to push force")]
    public float pushForce = 1.2f;
    [Tooltip("Upward alteration to level out with units")]
    public float upwardPull = 0.5f;

    private float startTime = 0.0f; //time this spell started, for timing
    private GameObject player;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        Attack();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > startTime + spellLifetime)
        {
            Destroy(gameObject);
        }
	}

    //gets all the enemies in the area
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

    //apply force and push away all enemies from centre
    private void PushOut()
    {
        //for all enemies in list
        for (int i = 0; i < enemies.Count; i++)
        {
            //get a directional vector towards center of circle and slightly up
            Vector3 slightlyUp = new Vector3(enemies[i].transform.position.x, enemies[i].transform.position.y + upwardPull, enemies[i].transform.position.z);
            Vector3 directionToPush = slightlyUp - transform.position;
            //apply a force to the body
            enemies[i].GetComponent<Rigidbody>().AddForce(directionToPush * pushForce, ForceMode.Impulse);
            //apply damage
            enemies[i].GetComponent<EnemyResourceBehaviour>().DecreaseHealth(damageValue);
        }
    }

    //attack sequence logic
    private void Attack()
    {
        //does all logic then destroys self

        GetAllInArea();
        PushOut();
        
        //Destroy(gameObject);
    }
}
