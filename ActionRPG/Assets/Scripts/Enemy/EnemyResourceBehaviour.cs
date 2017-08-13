using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyResourceBehaviour : MonoBehaviour {

    //script ref
    public string playerProgressionTag = ""; // tag for player progression object
    private PlayerProgressionManager progressionManager;

    [Header("Resource vars")]
    public float healthValue = 2.0f; //health value
    public float expGiven = 1.0f; //exp given to player when slain

    [Header("Drops")]
    public GameObject healthDrop; //health pickup
    public GameObject manaDrop; //mana pickup

	// Use this for initialization
	void Start () {
        progressionManager = GameObject.FindGameObjectWithTag("playerProgressionTag").GetComponent<PlayerProgressionManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //decrease health value
    public void DecreaseHealth(float damage)
    {
        healthValue -= damage;
        CheckDead();
    }

    //check dead
    public void CheckDead()
    {
        if (healthValue <= 0)
        {
            //call dead funcs
            DropLoot();
            GiveExp();
            //once done, destroy self
            Destroy(gameObject);
        }
    }

    //drop any loot that this enemy is holding
    private void DropLoot()
    {
        //if carrying the drops, drop it
        if (healthDrop)
        {
            GameObject healthClone = healthDrop;
            Instantiate(healthClone, transform.position, transform.rotation);
        }
        if (manaDrop)
        {
            GameObject manaClone = manaDrop;
            Instantiate(manaClone, transform.position, transform.rotation);
        }
    }

    //give exp to the player
    private void GiveExp()
    {
        progressionManager.IncreaseExp(expGiven);
    }
}
