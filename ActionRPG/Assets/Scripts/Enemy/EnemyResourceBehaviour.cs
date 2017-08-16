using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyResourceBehaviour : MonoBehaviour {

    //script ref
    public string playerProgressionTag = ""; // tag for player progression object
    private PlayerProgressionManager progressionManager;

    [Header("Resource vars")]
    public float maxHealth = 2.0f;
    public float healthValue; //health value
    public float expGiven = 1.0f; //exp given to player when slain

    [Header("Drops")]
    public GameObject healthDrop; //health pickup
    public GameObject manaDrop; //mana pickup
    public float healthDropAmount; //health value on health drop
    public float manaDropAmount; //mana value on mana drop

    [Header("UI")]
    public ProgressBar HealthBar;

	// Use this for initialization
	void Start () {
        healthValue = maxHealth;
        progressionManager = GameObject.FindGameObjectWithTag("playerProgressionTag").GetComponent<PlayerProgressionManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //decrease health value
    public void DecreaseHealth(float damage)
    {
        healthValue -= damage;
        print(healthValue);
        if(HealthBar) HealthBar.SetPercentage(healthValue / maxHealth);
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
            //give random rotation to loot
            Quaternion alteredRotation = new Quaternion();
            alteredRotation.eulerAngles = new Vector3(0.0f, Random.Range(0.0f, 359.0f), 0.0f);
            //set health restore value
            healthClone.GetComponent<LootDropBehaviour>().healthRestore = healthDropAmount;
            //spawn
            Instantiate(healthClone, transform.position, alteredRotation);
        }
        if (manaDrop)
        {
            GameObject manaClone = manaDrop;
            //give random rotation to loot
            Quaternion alteredRotation = new Quaternion();
            alteredRotation.eulerAngles = new Vector3(0.0f, Random.Range(0.0f, 359.0f), 0.0f);
            //set mana restore value
            manaClone.GetComponent<LootDropBehaviour>().manaRestore = manaDropAmount;
            //spawn
            Instantiate(manaClone, transform.position, alteredRotation);
        }
    }

    //give exp to the player
    private void GiveExp()
    {
        progressionManager.IncreaseExp(expGiven);
    }

    public float GetHealthPercentage()
    {
        return healthValue / maxHealth;
    }
}
