using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownBehaviour : MonoBehaviour {

    [Header("Transforms for points of interest")]
    [Tooltip("The spawn point when returning to the town")]
    public Transform townEntrySpawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform GetTownEntrySpawn()
    {
        return townEntrySpawnPoint;
    }
}
