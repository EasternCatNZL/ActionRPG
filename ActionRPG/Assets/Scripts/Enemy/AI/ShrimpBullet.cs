using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpBullet : MonoBehaviour {

    [Header("Bullet vars")]
    [Tooltip("Flight speed")]
    public float flightSpeed = 1.5f;
    [Tooltip("Amount of damage bullet deals")]
    public float damageValue = 0.5f;
    [Tooltip("Impact particle gameobject")]
    public GameObject impactParticle;

    private Rigidbody myRigid; //rigidbody ref
    private float startTime = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myRigid.position += transform.forward * flightSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if colliding with an enemy, deal damage
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EnemyResourceBehaviour>().DecreaseHealth(damageValue);
        }
        //regardless, create explosion object at impact point
        GameObject impactClone = impactParticle;
        Instantiate(impactClone, transform.position, transform.rotation);
        //destroy self afterwards
        Destroy(gameObject);
    }
}
