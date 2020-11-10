using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{

	public OtherMovementTest controller;

	public float speed = 40f;

	public float XMovement = 0f;
	public bool jump = false;
	// Update is called once per frame
	void Update()
	{
		XMovement = Input.GetAxisRaw("Horizontal") * speed;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Movement(XMovement * Time.deltaTime, jump);
		jump = false;
	}
}