using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float Speed = 5.0f;
    public float CurrentSpeed = 0.0f;
    [Range(0, 1)]
    public float TurnRate = 0.2f; //Must be set between 1 - 0

    private Vector3 Direction;
    private Vector3 PrevDirection;

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

            Direction += hit.point - transform.position;

            //Accumlate Direction so the model doesn't snap back
            //Direction.x += state.ThumbSticks.Left.X;
            //Direction.z += state.ThumbSticks.Left.Y;


           Direction.Normalize();

            Debug.DrawRay(this.transform.position, Direction * 5, Color.red);

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
            print(Vector3.Distance(transform.position, hit.point));
            if (Mathf.Abs(Vector3.Distance(transform.position, hit.point)) > 0.7f)
            {
                Rigid.MovePosition(transform.position + transform.forward * CurrentSpeed * Time.deltaTime);
            }

        }
    }
}