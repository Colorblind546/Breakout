using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveAbility;
    public float moveTimer;
    float moveTimerReset;
    public GameObject moveMeter;
    public Rigidbody rb;
    public float speed = 4f;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        moveTimerReset = moveTimer;
        rb.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-speed/2, -speed, 0);
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
        
        if (transform.position.y < 0f)
        {
            transform.position = new Vector3(0, 5, 0);
            rb.velocity = new Vector3(-speed / 2, -speed, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            active = true;
        }

        if (active && moveTimer > 0f)
        {
            moveTimer -= Time.deltaTime * 2f;
        }
        else if (!active && moveTimer < moveTimerReset)
        {
            moveTimer += Time.deltaTime / 15f;
        }
        else
        {
            active = false;
        }


        if (active)
        {
            var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.AddForce(direction.normalized, ForceMode.VelocityChange); 
        }

        AbilityMeter meter = moveMeter.GetComponent<AbilityMeter>();
        meter.MoveMeter(moveTimer, moveTimerReset);

    }
}
