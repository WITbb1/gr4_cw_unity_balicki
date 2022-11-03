using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCube : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public List<Material> Materials = new List<Material>();
    public int HowMany;
    public float delay = 3.0f;
    int objectCounter = 0;
    public int x_start;
    public int y_start;
    public int x_end;
    public int y_end;
    // obiekt do generowania
    public GameObject block;

    public GameObject platform;
    void Start()
    {
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(x_start, x_end).OrderBy(x => Guid.NewGuid()).Take(10));
        List<int> pozycje_z = new List<int>(Enumerable.Range(y_start, y_end).OrderBy(x => Guid.NewGuid()).Take(10));

        for (int i = 0; i < HowMany; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {

            var render = block.GetComponent<Renderer>();
            render.material = Materials[UnityEngine.Random.Range(0, Materials.Count)];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
