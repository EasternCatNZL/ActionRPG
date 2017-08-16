using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAttachment : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //dont destroy
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
