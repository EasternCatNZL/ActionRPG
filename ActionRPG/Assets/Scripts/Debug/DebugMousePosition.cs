using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make an object track the mouses position on objects in the world
public class DebugMousePosition : MonoBehaviour {

    public bool TrackFloorOnly = false;
	
	// Update is called once per frame
	void Update () {
        if (TrackFloorOnly)
        {
            transform.position = MouseTarget.GetWorldMousePos();
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);

            transform.position = hit.point;
        }
    }
}
