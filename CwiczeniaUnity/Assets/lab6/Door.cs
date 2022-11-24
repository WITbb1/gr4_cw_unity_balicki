using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject door;
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 1f;
    private bool isRunningNew = true;
    private bool isRunningBasic = false;
    private float basicPosition;
    private float newPosition;

    void Start()
    {
        newPosition = door.transform.position.x + distance;
        basicPosition = door.transform.position.x;
    }

    void Update()
    {
        if (isRunningNew && door.transform.position.x >= newPosition)
        {
            isRunning = false;
        }
        else if (isRunningBasic && door.transform.position.x <= basicPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = door.transform.right * elevatorSpeed * Time.deltaTime;
            door.transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (door.transform.position.x <= basicPosition)
            {
                isRunningNew = true;
                isRunningBasic = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }

            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (door.transform.position.x >= basicPosition)
            {
                isRunningBasic = true;
                isRunningNew = false;
                elevatorSpeed = -elevatorSpeed;
            }

            isRunning = true;
        

        }
    }
}


