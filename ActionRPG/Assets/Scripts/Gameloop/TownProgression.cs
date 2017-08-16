using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownProgression : MonoBehaviour {

    [Header("Town objects")]
    [Tooltip("Starting town object")]
    public GameObject startTownObject;
    [Tooltip("Second town object")]
    public GameObject secondTownObject;

    [Header("Character objects")]
    [Tooltip("Player object")]
    public GameObject playerObject;

    //control variables
    private enum TownCurrentState
    {
        Starting,
        Progressed
    }

    private TownCurrentState currentState = TownCurrentState.Starting; //current state of the town

	// Use this for initialization
	void Start () {
        //dont destroy
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //load the town based on current progression
    private void LoadTown()
    {
        //make clone object
        GameObject townClone = startTownObject;
        if (currentState == TownCurrentState.Starting)
        {
            townClone = startTownObject;
        }
        else if (currentState == TownCurrentState.Progressed)
        {
            townClone = secondTownObject;
        }
        //spawn the town
        Instantiate(townClone, Vector3.zero, Quaternion.identity);
        //spawn the player in
        LoadPlayer(townClone.GetComponent<TownBehaviour>().GetTownEntrySpawn());
    }

    //spawn the player into the towns spawn point when loading this scene normally
    private void LoadPlayer(Transform startTransform)
    {
        GameObject playerClone = playerObject;
        Instantiate(playerClone, startTransform.position, startTransform.rotation);
    }
}
