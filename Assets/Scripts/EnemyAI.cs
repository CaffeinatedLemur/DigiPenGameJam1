/////////////////////////////
///By: Frank Vanris
///Comments added by thomas allen. Slight risk of them being inaccurate.
///Date: 11/4/2020
///Desc: This will be the enemy AI where if the enemy collides with a wall it changes direction.
///Credit: I believe that this was partially from a tutorial. Frank has not told me what it was to give credit.
////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{   
    //how fast the enemy moves
    public float speed;
    //distance of the raycast
    public float distance = 0.5f;

    //the enemy to be affected by the AI
    public GameObject Enemy;
    
    //wether of not to mvoe to the right
    private bool moveRight = true;
    //collider
    public BoxCollider2D collisionDetection;
    //transform of ground detector object
    public Transform groundDetection;

    void Start()
    {
        Enemy = GameObject.Find("Enemy"); //find the enemy
        collisionDetection = GetComponent<BoxCollider2D>(); //find the collider
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Mathf.Abs(collision.GetContact(0).normal.x) >= .5f) //make sure it is a valid collision
        {
            //move to the right
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            //move the the left
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }

        }
        
    }


    
    private void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);//update transform and vector2

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance); //draw the raycast

        //move if not going to fall off a ledge
        if(groundInfo.collider == false) 
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }

    }


}
