using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody2D myRb;
    SoundPlayonEvent sound;

    public float dashSpeed;
    public bool hasDashed;

    public float xRaw;
    public float yRaw;
    // Start is called before the first frame update
    void Start()
    {
        // Gets sound script from sound source object
        GameObject source = GameObject.Find("Sound Source");
        sound = source.GetComponent<SoundPlayonEvent>();

        myRb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        xRaw = Input.GetAxisRaw("Horizontal");
        yRaw = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && !hasDashed)
        {
            if (xRaw != 0 || yRaw != 0)
                dash(xRaw, yRaw);
        }
    }

    public void dash(float x, float y)
    {
        if (!hasDashed)
        {
            hasDashed = true;

            myRb.velocity = Vector2.zero;
            Vector2 DashVector = new Vector2(x, y);

            myRb.velocity += DashVector.normalized * dashSpeed;
            sound.PlaySound("Dash");
        }
    }
}
/*
    public Rigidbody2D rb;

    public float speed;
    public float time;
    public float startTime;

    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (direction == 0)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
                if (Input.GetKeyDown(KeyCode.D))
                {
                    direction = 1;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    direction = 2;
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    direction = 3;
                }

                if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.W))
                {
                    direction = 4;
                }
                if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.W))
                {
                    direction = 5;
                }
           // }
        }
        else
        {
            if (time <= 0)
            {
                direction = 0;
                time = startTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                time -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.right * speed;
                }
                if (direction == 2)
                {
                    rb.velocity = Vector2.left * speed;
                }
                if (direction == 3)
                {
                    rb.velocity = Vector2.up * speed;
                }

                if (direction == 4)
                {
                    rb.velocity = (Vector2.up + Vector2.left) * speed;
                }
                if (direction == 5)
                {
                    rb.velocity = (Vector2.up + Vector2.right) * speed;
                }
            }
        }
    }
    */
