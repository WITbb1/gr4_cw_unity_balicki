using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform[] waypoint;
    public int index;

    public float Range;
    public float speed = 2;
    public Transform target;
    void Start()
    {
        index = 0;
        target = waypoint[0];
    }
    public void NextPosition()
    {

        if (index + 1 == waypoint.Length)
        {
            index = 0;
            target = waypoint[index];
        }
        else
        {
            index += 1;
            target = waypoint[index];
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            target = other.GetComponent<Transform>();
        }
    }
        // Update is called once per frame
        void FixedUpdate()
    {
        {

            //rotate to look at the player
            if (false)
            {
                transform.LookAt(target.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, target.position) > 1f)
                {//move if distance from target is greater than 1
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
            }
            else
            {
                transform.LookAt(target.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));

                if (Vector3.Distance(transform.position, target.position) < 1f)
                {
                    NextPosition();
                }

            }
        }

    }
}