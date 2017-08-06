using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour {

    //debug thing
    public GameObject thing;

    //transform for other scripts
    [HideInInspector]
    public Transform mouseTargetPos;

    //raycast stuff
    public float rayLength; //length of ray
    public LayerMask myMask; //layermask for raycast

    private RaycastHit rayHit; //ray hit info

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        GetWorldMousePos();
	}

    //return the position in world floor surface that the mouse is at
    void GetWorldMousePos()
    {
        //send a ray from the position of mouse on screen
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayHit, rayLength, myMask))
        {
            GameObject clone = thing;
            Instantiate(clone, rayHit.point, Quaternion.identity);
        }
    }
}
