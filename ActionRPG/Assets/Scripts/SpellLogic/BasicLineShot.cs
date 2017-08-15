using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLineShot : MonoBehaviour {

    [Header("Bullet vars")]
    [Tooltip("speed at which bullet flies")]
    public float flightSpeed = 3.0f;
    [Tooltip("Amount of damage bullet deals")]
    public float damageValue = 0.5f;
    [Tooltip("Explosion vfx")]
    public GameObject impactVfxObject;

    private Rigidbody myRigid; //rigidbody ref
    private float startTime = 0.0f;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        myRigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //if(Time.time - startTime > 5.0f)
        //{
        //    Destroy(gameObject);
        //}
        myRigid.position += transform.forward * flightSpeed;
	}

    private void OnCollisionEnter(Collision collision)
    {
        //if colliding with an enemy, deal damage
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyResourceBehaviour>().DecreaseHealth(damageValue);
        }
        //regardless, create explosion object at impact point
        GameObject impactClone = impactVfxObject;
        Instantiate(impactClone, transform.position, transform.rotation);
        //destroy self afterwards
        Destroy(gameObject);
    }
}
