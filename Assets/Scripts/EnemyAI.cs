/////////////////////////////
///By: Frank Vanris
///Date: 11/4/2020
///Description: This will be the enemy AI where if the enemy collides with a wall it changes direction.
////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;

    public GameObject Enemy;
    

    private bool moveRight = true;

    public BoxCollider2D collisionDetection;

    public Transform groundDetection;

    void Start()
    {
        Enemy = GameObject.Find("Enemy");
        collisionDetection = GetComponent<BoxCollider2D>();
    }
   

    private void objectCollision()
    {
        if( collisionDetection == true)
        {
            
           
                if (moveRight == true)
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
    
    private void Update()
    {
      //  this.objectCollision();

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down);

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
