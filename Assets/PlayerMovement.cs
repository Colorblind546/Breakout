using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    float sprint = 1.5f;
    float speedReset;
    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        speedReset = speed;
        sprint = speed * sprint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprint;
        }
        else
        {
            speed = speedReset;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }

        if (ball.transform.position.y < 0)
        {
            transform.position = Vector3.zero;
        }
    }
}
