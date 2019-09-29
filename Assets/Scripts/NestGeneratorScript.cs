using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestGeneratorScript : MonoBehaviour
{
    public float Xsize = 13.5f;
    public float Zsize = 6.5f;
    public GameObject nestPrefab;
    public Vector3 curPos;
    public GameObject curNest;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!curNest)
        {
            GenerateRandomPosition();
            curNest = GameObject.Instantiate(nestPrefab, curPos, Quaternion.identity);
            curNest.tag = "Nest";
        }

    }

    void GenerateRandomPosition()
    {
        curPos = new Vector3(Random.Range(Xsize * -1, Xsize), 0, Random.Range(Zsize * -1, Zsize));
    }
}
