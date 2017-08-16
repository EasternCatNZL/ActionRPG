using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            GameObject objectHit;
            RaycastHit rayHit; //ray hit info
                               //send a ray from the position of mouse on screen
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out rayHit, Mathf.Infinity);

            if (rayHit.collider != null)
            {
                objectHit = rayHit.collider.gameObject;
                if (objectHit.CompareTag("Interactable"))
                {                    
                    objectHit.GetComponent<Interactable>().Interact();
                }

            }

        }
	}
}
