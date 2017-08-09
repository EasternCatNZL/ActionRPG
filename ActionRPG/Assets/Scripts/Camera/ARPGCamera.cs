using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ARPGCamera : MonoBehaviour {

    [Header("Camera Settings")]
    public Transform TrackingTarget = null;
    public float ZoomAmount = 5.0f;
    public float ZoomIntervals = 1.0f;
    public float ZoomMin = 0.0f;
    public float ZoomMax = 10.0f;
    [Range(0,90)]
    public float CameraAngle = 25.0f;
    public float ZoomAngleRatio = 25.0f;
    
	// Use this for initialization
	void Start () {
        //Set Inital Camera Zoom
        Vector3 CameraPosition = new Vector3(0.0f, 0.0f, -ZoomAmount);
        Camera.main.transform.localPosition = CameraPosition;
        //Set Inital Camera Angle
        CameraAngle = ZoomAmount * ZoomAngleRatio;
        Vector3 CameraRotation = new Vector3(CameraAngle, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(CameraRotation);

	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            if(ZoomAmount > ZoomMin)
            {
                //Update Camera Zoom and Angle
                ZoomAmount -= ZoomIntervals;           
                CameraAngle = ZoomAmount * ZoomAngleRatio;
           
                MoveCamera(ZoomAmount, CameraAngle);
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            if (ZoomAmount < ZoomMax)
            {
                //Update Camera Zoom and Angle
                ZoomAmount += ZoomIntervals;
                CameraAngle = ZoomAmount * ZoomAngleRatio;

                MoveCamera(ZoomAmount, CameraAngle);
            }
        }
        //Update position to tracked object
        transform.position = TrackingTarget.position;
	}

    public void MoveCamera(float _Zoom, float _Angle)
    {
        Vector3 CameraPosition = new Vector3(0.0f, 0.0f, -_Zoom);
        Camera.main.transform.DOLocalMove(CameraPosition, 1.0f);

        Vector3 CameraRotation = new Vector3(_Angle, 0.0f, 0.0f);
        transform.DORotate(CameraRotation, 1.0f);
    }
}
