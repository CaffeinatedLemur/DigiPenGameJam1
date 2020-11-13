////////////////
//Name: Thomas Allen
//Script by: Ryan Scheppler
//Date: 11/6/2020
//Description: Basic horzontal directional movement, jump, and dash
//Edit by: Owen Whitehouse (sound purposes)
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //how fast you go up
    public float Speed = 10;
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    //wether or not you can jump
    public bool canJump = true;
    public bool canDash = false;
    public bool HasJumped = false;

    //get rigidbody of player
    Rigidbody2D myRb;

    // Sound manager script
    SoundPlayonEvent sound;

    //vector2s for jump and dash
    public Vector2 height;
    public Vector2 dash;
    public Vector2 negdash;


    // Start is called before the first frame update
    void Start()
    {
        // Sets game object of sound source to find script on it
        GameObject soundSource = GameObject.Find("Sound Source");
        myRb = GetComponent<Rigidbody2D>();

        dash.x = 12;
        negdash.x = -12;

        // Uses script from sound source object and sets it for use
        sound = soundSource.GetComponent<SoundPlayonEvent>();
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
            //myRb.AddForce(height, ForceMode2D.Impulse);
            myRb.velocity = Vector2.up * jumpVelocity;
            canJump = false;
            canDash = true;
            HasJumped = true;
            sound.PlaySound("Jump");
        }

        if (myRb.velocity.y < 0)
        {
            myRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        

        /*
        if (Input.GetKey(KeyCode.Space) && HasJumped && canDash)
        {
            if (myRb.velocity.x > 0)
            {
                dash.y = myRb.velocity.y * 2;
                myRb.velocity = (dash);

                // plays dash sound
                sound.PlaySound(2);
            }
            else if (myRb.velocity.x < 0)
            {
                dash.y = myRb.velocity.y * 2;

                myRb.velocity = negdash;

                // plays dash sound
                sound.PlaySound(2);
            }
            canDash = false;

            //myRb.velocity = (dash);
        }
        */

        //update dash cooldown

    }

    //make sure the player is on the ground
    public void OnCollisionEnter2D (Collision2D collision)
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
