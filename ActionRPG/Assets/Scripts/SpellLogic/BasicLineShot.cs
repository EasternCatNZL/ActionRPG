using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLineShot : MonoBehaviour {

    [Header("Bullet vars")]
    public float flightSpeed = 3.0f; //speed at which bullet flies

    private Rigidbody myRigid; //rigidbody ref
    private float startTime = 0.0f;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        myRigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time - startTime > 5.0f)
        {
            Destroy(gameObject);
        }
        myRigid.position += transform.forward * flightSpeed;
	}
}
