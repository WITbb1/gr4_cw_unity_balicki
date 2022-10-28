using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{

    public float Speed = 2;
    public bool Foward = true;


    public float Distance = 0;
    public Vector3 Position;


    // Start is called before the first frame update
    void Start()
    {
        Position = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Foward )
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
        else if (!Foward)
        {
            transform.Translate(0, 0, -Speed * Time.deltaTime);

        }
        if (Distance >= 10)
        {
            Distance = 0;
            Foward = !Foward;
            Position = transform.position;

        }

        Distance = Vector3.Distance(transform.position, Position);

    }
}
