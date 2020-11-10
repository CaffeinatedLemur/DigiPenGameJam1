//////////////////////////////
///Name: Ryan Scheppler
///Date: 10/23/2020
///Desc: Add to objects that need to trigger the camera shake with unity events
//////////////////////////////////


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