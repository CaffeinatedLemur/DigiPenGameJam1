﻿using UnityEngine;

public class OtherMovementTest : MonoBehaviour
{
	public float JumpForce = 400f;                        
	public float smoothThing = .05f;  


	public bool canJump;            // Whether or not the player is on the ground.
	public Rigidbody2D myRb;
	private bool DirectionFacing = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;




	//how fast you go up and down
	public float jumpVelocity;
	public float fallMultiplier = 2.5f;
	public float jumpGravity = 0.5f;

	//get rigidbody of player
    public void Start()
    {
		myRb = GetComponent<Rigidbody2D>();
	}



    public void Movement(float move, bool jump)
	{
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(move * 10f, myRb.velocity.y);
		// And then smoothing it out and applying it to the character
		myRb.velocity = Vector3.SmoothDamp(myRb.velocity, targetVelocity, ref velocity, smoothThing);

		if (move > 0 && !DirectionFacing)
		{
			Flip();
		}
		else if (move < 0 && DirectionFacing)
		{
			Flip();
		}
		
		// If the player should jump...
		if (canJump && jump)
		{

			//myRb.velocity = Vector2.up * Physics2D.gravity.y * (jumpGravity - 1) * Time.deltaTime * jumpVelocity;
			myRb.AddForce(new Vector2(0f, JumpForce));

		}

		if (myRb.velocity.y < 0)
		{
			myRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}

		canJump = false;

	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		DirectionFacing = !DirectionFacing;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "canJump")
		{
			//reset boolean
			canJump = true;
			
			//HasJumped = false;
		}

	}
}