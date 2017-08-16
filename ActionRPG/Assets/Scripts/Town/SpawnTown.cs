using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTown : MonoBehaviour {

    //script ref
    private TownProgression townProgression;

    [Header("Town location")]
    [Tooltip("The position the town is situated in the world")]
    public Transform townPos;

	// Use this for initialization
	void Start () {
        townProgression = GameObject.FindGameObjectWithTag("Manager").GetComponent<TownProgression>();
        townProgression.LoadTown(townPos);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
