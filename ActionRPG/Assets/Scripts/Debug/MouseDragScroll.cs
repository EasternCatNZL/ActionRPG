using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseDragScroll : MonoBehaviour {

    Vector3 StartPos = Vector3.zero;

    private bool Moving = false;
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            Moving = true;
            StartPos = Input.mousePosition;
        }
        if(Moving)
        {
            Vector3 Diff = Input.mousePosition - StartPos;
            Diff /= 5;
            transform.DOMove(new Vector3(transform.position.x + Diff.x, transform.position.y + Diff.y, transform.position.z + Diff.z), 0.5f);
            //transform.position = new Vector3(transform.position.x + Diff.x, transform.position.y + Diff.y, transform.position.z + Diff.z);
            StartPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            Moving = false;
        }

	}
}
