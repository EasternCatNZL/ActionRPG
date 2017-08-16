using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    static public GameObject Player = null;

    public static GameObject GetPlayer()
    {
        if(!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            return Player;
        }
        else
        {
            return Player;
        }

    }
}
