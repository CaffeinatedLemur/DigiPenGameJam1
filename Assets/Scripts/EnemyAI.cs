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

    private bool moveRight = true;

    public Transform GroundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D Dimension;
    }


}
