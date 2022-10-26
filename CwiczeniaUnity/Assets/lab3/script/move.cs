using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float Speed = 1;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(new Vector3(0, -1, 0) * 1, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(new Vector3(0, 1, 0) * 1, Space.World);

        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.forward * Speed, ForceMode.Impulse);
        }

       
    }
}
