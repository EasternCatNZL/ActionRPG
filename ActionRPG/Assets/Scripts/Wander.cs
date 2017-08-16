using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public float Radius = 0.5f;

    private Vector3 Direction;
    private float PI = 3.1415f;

    private void Update()
    {
        int iRand = Random.Range(0, 360);

        Vector3 randomDirection = new Vector3(Mathf.Sin(iRand * PI / 180.0f), 0.0f, Mathf.Cos(iRand * PI / 180.0f));
        randomDirection *= Radius;
    }

}
