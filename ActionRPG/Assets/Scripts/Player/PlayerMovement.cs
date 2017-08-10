﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float Speed = 5.0f;
    private float CurrentSpeed = 0.0f;
    [Range(0, 1)]
    public float TurnRate = 0.2f; //Must be set between 1 - 0

    private Vector3 Direction;
    private Vector3 PrevDirection;

    private Vector3 MovePosition;

    private Rigidbody Rigid;

    // Use this for initialization
    void Start()
    {
        Direction = new Vector3(0.0f, 0.0f, 0.0f);

        Rigid = GetComponent<Rigidbody>();
        Rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            CurrentSpeed = Speed;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);

            MovePosition = hit.point;

            Direction += hit.point - transform.position;

            Direction.Normalize();

            //Player Rotations
            if (Vector3.Dot(transform.right, Direction) < 0.0f)
            {
                transform.Rotate(0.0f, -Vector3.Angle(transform.forward, Direction) * TurnRate, 0.0f);
            }
            if (Vector3.Dot(transform.right, Direction) > 0.0f)
            {
                transform.Rotate(0.0f, Vector3.Angle(transform.forward, Direction) * TurnRate, 0.0f);
            }
            //Move the player forward
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (Mathf.Abs(Vector3.Distance(transform.position, hit.point)) > 0.7f)
                {
                    Rigid.MovePosition(transform.position + transform.forward * CurrentSpeed * Time.deltaTime);
                }
            }
            else
            {
                MovePosition = transform.position;
            }

        }
        if(Vector3.Distance(transform.position, MovePosition) > 0.7f)
        {
            Direction += MovePosition - transform.position;

            Direction.Normalize();
            Rigid.MovePosition(transform.position + Direction * CurrentSpeed * Time.deltaTime);
        }
        Debug.DrawLine(transform.position, MovePosition, Color.red);
    }
}