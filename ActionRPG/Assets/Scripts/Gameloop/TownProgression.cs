using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownProgression : MonoBehaviour {

    [Header("Town objects")]
    [Tooltip("Starting town object")]
    public GameObject startTownObject;
    [Tooltip("Second town object")]
    public GameObject midTownObject;
    [Tooltip("Third town object")]
    public GameObject largeTownObject;

    [Header("Character objects")]
    [Tooltip("Player object")]
    public GameObject playerObject;

    //control variables
    private enum TownCurrentState
    {
        Starting,
        Progressed,
        Complete
    }

    private TownCurrentState currentState = TownCurrentState.Starting; //current state of the town

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //load the town based on current progression
    public void LoadTown(Transform location)
    {
        //make clone object
        GameObject townClone = startTownObject;
        //get town object based on current state of town
        if (currentState == TownCurrentState.Starting)
        {
            townClone = startTownObject;
        }
        else if (currentState == TownCurrentState.Progressed)
        {
            townClone = midTownObject;
        }
        else if (currentState == TownCurrentState.Complete)
        {
            townClone = largeTownObject;
        }
        //spawn the town
        Instantiate(townClone, location.position, Quaternion.identity);
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
