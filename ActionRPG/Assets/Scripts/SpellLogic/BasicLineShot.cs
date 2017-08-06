using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLineShot : MonoBehaviour {

    [Header("Bullet vars")]
    public float flightSpeed = 3.0f; //speed at which bullet flies

    private Rigidbody myRigid; //rigidbody ref

	// Use this for initialization
	void Start () {
        myRigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        myRigid.position += transform.forward * flightSpeed;
	}

   
}
