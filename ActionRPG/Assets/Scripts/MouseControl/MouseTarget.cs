using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour {

    //debug thing
    //public GameObject thing;
    //transform for other scripts
    //return the position in world floor surface that the mouse is at

    static public Vector3 GetWorldMousePos()
    {
        //raycast stuff
        RaycastHit rayHit; //ray hit info
        //send a ray from the position of mouse on screen
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, 256))
        //if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
            {
            //dubug spawn object
            //GameObject clone = thing;
            //Instantiate(clone, rayHit.point, Quaternion.identity);

            //set the mouse screen to world pos
            return rayHit.point;
        }
        return Vector3.zero;
    }
}
