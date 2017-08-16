using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(CapsuleCollider))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Range(0, 1)]
    public float Deadzone = 0.5f;
    public float Speed = 5.0f;
    private float CurrentSpeed = 0.0f;
    [Range(0, 1)]
    public float TurnRate = 0.2f; //Must be set between 1 - 0

    private Vector3 Direction;
    private Vector3 PrevDirection;

    private Vector3 MovePosition;
    private bool DoMove = false;

    private Rigidbody Rigid;
    private Animator Animator; 

    // Use this for initialization
    void Start()
    {
        Direction = new Vector3(0.0f, 0.0f, 0.0f);

        Animator = GetComponent<Animator>();

        Rigid = GetComponent<Rigidbody>();
        Rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            CurrentSpeed = Speed;

            Vector3 MouseHit = MouseTarget.GetWorldMousePos();

            MovePosition = MouseHit;

            Direction += MouseHit - transform.position;

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
                Animator.SetBool("Moving", true);
                if (Mathf.Abs(Vector3.Distance(transform.position, MouseHit)) > Deadzone)
                {
                    Rigid.MovePosition(transform.position + transform.forward * CurrentSpeed * Time.deltaTime);
                }
                DoMove = true;
            }
            //Stop the player when they press shift
            else
            {
                Animator.SetBool("Moving", false);
                MovePosition = transform.position;
            }

        }

        //Continue to move the player forward after mouse click
        if (Vector3.Distance(transform.position, MovePosition) > Deadzone && DoMove)
        {
            Direction += MovePosition - transform.position;

            Direction.Normalize();
            Rigid.MovePosition(transform.position + Direction * CurrentSpeed * Time.deltaTime);
        }
        else
        {
            Animator.SetBool("Moving", false);
            DoMove = false;
        }
        Debug.DrawLine(transform.position, MovePosition, Color.red);
    }

    public void FacePosition(Vector3 _pos)
    {
        Direction = _pos - transform.position;

        Direction.Normalize();

        //Player Rotations
        if (Vector3.Dot(transform.right, Direction) < 0.0f)
        {
            transform.Rotate(0.0f, -Vector3.Angle(transform.forward, Direction), 0.0f);
        }
        if (Vector3.Dot(transform.right, Direction) > 0.0f)
        {
            transform.Rotate(0.0f, Vector3.Angle(transform.forward, Direction), 0.0f);
        }
    }

    public void SetSpeed(float _Speed)
    {
        Speed = _Speed;
    }

    public void StopMovement()
    {
        DoMove = false;
    }
}