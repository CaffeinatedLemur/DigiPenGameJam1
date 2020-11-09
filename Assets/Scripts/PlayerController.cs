////////////////
//Name: Thomas Allen
//Script by: Ryan Scheppler
//Date: 11/6/2020
//Description: Basic horzontal directional movement, jump, and dash
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
    public bool canDash = false;
    public bool HasJumped = false;

    //get rigidbody of player
    Rigidbody2D myRb;

    //vector2s for jump and dash
    public Vector2 height;
    public Vector2 dash;
    public Vector2 negdash;



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
        if (Input.GetKey(KeyCode.W) && canJump && !HasJumped)
        {
            myRb.AddForce(height, ForceMode2D.Impulse);
            canJump = false;
            canDash = true;
            HasJumped = true;
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
        if (Input.GetKey(KeyCode.Space) && HasJumped && canDash)
        {
            if (myRb.velocity.x > 0)
            {
                dash.y = myRb.velocity.y * 2;
                myRb.velocity = (dash);
            }
            else if (myRb.velocity.x < 0)
            {
                dash.y = myRb.velocity.y * 2;

                myRb.velocity = negdash;
            }
            canDash = false;

            //myRb.velocity = (dash);
        }

        //update dash cooldown

    }

    //make sure the player is on the ground
    public void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "canJump")
        {
            //reset boolean
            canJump = true;
            canDash = false;
            HasJumped = false;
        }
       
    }
}
