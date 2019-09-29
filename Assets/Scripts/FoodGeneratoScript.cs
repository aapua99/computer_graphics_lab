using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneratoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float ZSize = 13.5f;
    public float Xsize = 11f;
    public GameObject applePrefab;
    public Vector3 curPos;
    public GameObject curFood;
    void Start()
    {

    }

    void GenerateRandomPosition()
    {
        curPos = new Vector3(Random.Range(Xsize * -1, Xsize), 0, Random.Range(ZSize * -1, ZSize));
    }

    // Update is called once per frame
    void Update()
    {
        if (!curFood)
        {
            GenerateRandomPosition();
            curFood = GameObject.Instantiate(applePrefab, curPos, Quaternion.identity);
            curFood.tag = "Food";
            Rigidbody rigidbody = curFood.AddComponent<Rigidbody>();
            rigidbody.mass = (float)0.01f;
        }

    }
}
