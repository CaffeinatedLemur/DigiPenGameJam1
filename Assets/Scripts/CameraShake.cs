/////////////////////////
///Name: Ryan Scheppler
///Date: 10/23/2020
///Desc. Add to the camera causes screenshaking! (camera should avoid non lerp movements otherwise)
////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Tooltip("How long the shaking persists")]
    public static float ShakeDuration = 0;
    [Tooltip("How much it shakes")]
    public static float ShakeMagnitude = 0.3f;
    [Tooltip("Adjust this to change how fast the duration depletes (higher number faster depletion)")]
    public static float DampingSpeed = 1.0f;

    public static void TriggerShake(float duration, float magnitude) //trigger the camera shake on the camera 
    {
        if (ShakeDuration <= 0)
        {
            ShakeMagnitude = magnitude;
        }
        else if (magnitude > ShakeMagnitude)
        {
            ShakeMagnitude = magnitude;
        }

       
        if (duration > ShakeDuration)
        {
            ShakeDuration = duration;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //should we be shaking?
        if (ShakeDuration > 0)
        {
            transform.position = (Vector3)Random.insideUnitCircle * ShakeMagnitude + transform.position;
            ShakeDuration -= Time.deltaTime * DampingSpeed;
        }

    }
}

