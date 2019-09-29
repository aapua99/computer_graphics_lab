using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovementScript : MonoBehaviour
{
    private const string FOOD_TAG = "Food";
    private const string BORDER_TAG = "Border";
    private const string NEST_TAG = "Nest";

    public float speed;
    public int life;
    public float rotationSpeed;
    public Text lifeText;
    // Start is called before the first frame update
    void Start()
    {
        life = 0;
        UpdateTextLife();
    }

    // Update is called once per framem
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -1 * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.name);
        switch (other.gameObject.tag)
        {
            case NEST_TAG:
                Destroy(other.gameObject);
                life += 1;
                UpdateTextLife();
                break;
            case FOOD_TAG:
                if (Input.GetKey(KeyCode.Space))
                {
                    Destroy(other.gameObject);
                }
                break;
            case BORDER_TAG:
                if (life > 0)
                {
                    life -= 1;
                    UpdateTextLife();
                }
                else
                {
                    SetLabelGameOver();
                }
                break;

        }

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == FOOD_TAG)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(other.gameObject);
            }
        }
    }
    private void UpdateTextLife()
    {
        lifeText.text = "Life: " + life.ToString();
    }

    private void SetLabelGameOver()
    {
        lifeText.text = "Game Over";
        speed = 0;
        rotationSpeed = 0;
    }
}
