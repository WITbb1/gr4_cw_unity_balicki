using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject SpawningObject;
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnCube();
        }
    }
    public void SpawnCube()
    {
        bool CheckSpawn = true;

        while (CheckSpawn) {
            Vector3 SpawnLocation = new Vector3(Random.Range(-5, 5), 4, Random.Range(-5, 5));
            if (!Physics.CheckSphere(SpawnLocation,0.5f))
            {
                Instantiate(SpawningObject, SpawnLocation, Quaternion.identity);
                CheckSpawn= false;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
