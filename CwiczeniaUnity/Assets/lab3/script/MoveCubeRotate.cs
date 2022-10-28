using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeRotate : MonoBehaviour
{

    public float Speed = 5;
    public float Distance = 0;
    public Vector3 Position;

    public Rigidbody rb;

    void Start()
    {
        Position = transform.position;
    }
    void Update()
    {

            rb.velocity = transform.forward * Speed;
 

        if (Distance >= 10)
        {
            Distance = 0;
            Position = transform.position;
            transform.Rotate(new Vector3(0, 1, 0) * 90, Space.World);
        }

        Distance = Vector3.Distance(transform.position, Position);

    }
}
