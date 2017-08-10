using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorBehaviour : MonoBehaviour {

    //mouse target ref
    private MouseTarget mouseTarget;

    //ref to player
    [HideInInspector]
    public GameObject player;

    // Use this for initialization
    void Start () {
        mouseTarget = Camera.main.GetComponent<MouseTarget>();
    }
	
	// Update is called once per frame
	void Update () {
        AlignIndicator();

        //if mouse input, destoy self
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
	}

    //moves the indicator, aligned with the player
    void AlignIndicator()
    {
        //get position of mouse
        //mouseTarget.GetWorldMousePos();
        //set indicator to position of mouse
        transform.position = MouseTarget.GetWorldMousePos();
        //align rotation using direction from player
        Vector3 directionToFire = MouseTarget.GetWorldMousePos() - player.transform.position;
        Quaternion rotationDirection = new Quaternion();
        rotationDirection = Quaternion.LookRotation(directionToFire);
        rotationDirection.x = 0.0f;
        rotationDirection.z = 0.0f;
        transform.rotation = rotationDirection;
    }

    //destroy self
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
