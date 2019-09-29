using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeTailMovement : MonoBehaviour
{
    private const string MAIN_SNAKE_TAG = "MainSnake";
    public float speed;
    public float rotationSpeed;
    public GameObject tailTarget;
    public Vector3 tailTargetVector;
    public SnakeMovementScript snakeMovement;
    void Start()
    {
        snakeMovement = GameObject.FindGameObjectWithTag(MAIN_SNAKE_TAG).GetComponent<SnakeMovementScript>();
        tailTarget = snakeMovement.gameObject;
        speed = snakeMovement.speed;
        rotationSpeed = snakeMovement.rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = snakeMovement.speed;
        tailTargetVector = tailTarget.transform.position;
        transform.LookAt(tailTargetVector);
        transform.position = Vector3.Lerp(transform.position, tailTargetVector, Time.deltaTime * speed);

    }
}
