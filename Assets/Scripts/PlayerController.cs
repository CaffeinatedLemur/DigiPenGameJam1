////////////////
//Name: Thomas Allen
//Script by: Ryan Scheppler
//Date: 10/19/2020
//Description: Basic 4 directional movement
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //how fast you go up
    public float Speed = 10;
   
    //wether or not you can jump
    public bool canJump = true;

    //get rigidbody of player
    Rigidbody2D myRb;

    //vector2s for jump and dash
    public Vector2 height;
    public Vector2 dash;
    public Vector2 negdash;

    //cooldown for dash
    public float timer = 0;
    public float Cooldown = 10;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();

        dash.x = 12;
        negdash.x = -12;
    }


    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {

        Vector2 movement = new Vector2();

        //set the forward and backward speeds
        myRb.AddForce(transform.up * movement.y * Speed * Time.deltaTime);
        //move right
        if (Input.GetKey(KeyCode.D))
        {
            myRb.AddForce(transform.right * Speed * Time.deltaTime);
        }
        //move left
        else if (Input.GetKey(KeyCode.A))
        {
            myRb.AddForce(transform.right * -Speed * Time.deltaTime);
        }
        //jump
        if (Input.GetKey(KeyCode.W) && canJump)
        {
            myRb.AddForce(height, ForceMode2D.Impulse);
            canJump = false;
        }

        /*
        //set dash direction
        if (!((dash.x = myRb.velocity.x) < 0))
        {
            print("works");
            dash.x = -12;
        }
        else if ((dash.x = myRb.velocity.x) == 0)
        {
            dash.x = 0;
        }
        else
        {
            dash.x = 12;
        }

        if ((dash.x = myRb.velocity.x) < 0)
        {
            
            dash.x = 12;
        }
        */
        //dash
        if (Input.GetKey(KeyCode.Space) && timer >= Cooldown)
        {
            timer = 0;

            if (myRb.velocity.x > 0)
            {
                
                myRb.velocity = (dash);
            }
            else if (myRb.velocity.x < 0)
            {
                myRb.velocity = negdash;
            }
            else
            {
                timer = 3;
            }
            //myRb.velocity = (dash);
        }

        //update dash cooldown
        timer += Time.deltaTime;

    }

    //make sure the player is on the grgound
    public void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "canJump")
        {
            //reset boolean
            canJump = true;            
        }
       
    }
}
