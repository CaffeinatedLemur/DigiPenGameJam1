///////////////
///name: Thomas Allen
///Date: 11/12/2020
///desc: Triggers the shakign effect on the camera
///Credit: Shell by Ryan Scheppler, with modifications
//////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    [Tooltip("How long the shake lasts for")]
    public float duration = .5f;
    [Tooltip("How intense the shake is")]
    public float magnitude = .05f;
    public void Trigger()
    {
        //engage shaking
        CameraShake.TriggerShake(duration, magnitude);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}