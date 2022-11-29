using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3[] objective;
    public float elevatorSpeed = 2f;
    private bool isRunningFoward = true;
    private int index;
    private Vector3 nextPosition;
    private Vector3 startPosition;

    void Start()
    {
        index = 0;
        startPosition = transform.position;
        nextPosition = startPosition + objective[index];

    }

    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, elevatorSpeed * Time.deltaTime);

        if (transform.position == nextPosition)
        {
            if(isRunningFoward )
            {
                nextPosition = startPosition+objective[index];
                if (index == objective.Length-1)
                {
                    isRunningFoward= false;
                }
                else
                {
                    index++;
                }    
            }
            else if (!isRunningFoward)
            {
                if(index==0)
                {
                    nextPosition = startPosition;
                    isRunningFoward = true;
                }
                else
                {
                    index--;
                    nextPosition = startPosition+objective[index];
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

}
