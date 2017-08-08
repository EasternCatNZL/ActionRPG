using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawIn : MonoBehaviour {

    //array of enemies in area
    private Collider[] thingsInArea = new Collider[0];
    private List<GameObject> enemies = new List<GameObject>();

    [Header("Spell vars")]
    public float effectRadius = 4.0f;
    public float pullForce = 3.0f;
    public float upwardPull = 10.0f;

	// Use this for initialization
	void Start () {
        Attack();
    }
	
	// Update is called once per frame
	void Update () {
        
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

    //attack sequence logic
    private void Attack()
    {
        //does all logic then destroys self
        GetAllInArea();
        PullIn();
        Destroy(gameObject);
    }
}
