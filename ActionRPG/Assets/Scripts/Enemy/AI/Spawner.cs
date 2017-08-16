using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;

    private int EnemyCount = 0;
    public int MaxEnemyCount = 10;

    // Use this for initialization
	void Start () {
        InvokeRepeating("Spawning", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawning()
    {
        int SpawnPointIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(EnemyPrefab, SpawnPoints[SpawnPointIndex].position, SpawnPoints[SpawnPointIndex].rotation);
        EnemyCount++;
        if(EnemyCount >= MaxEnemyCount)
        {
            CancelInvoke("Spawning");
        }

    }
}
