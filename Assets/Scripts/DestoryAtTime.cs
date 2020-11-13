/***************
* by: Ryan Shepppler
* Writen out by: Turin Thompson and Thomas Allen
* Date: 11/12/2020
* brief: DESTROYS game objects after 3 or more seconds
* note: grabbed from TopDownGame, but might be adapted
* ***********/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAtTime : MonoBehaviour
{
    [Tooltip("how long the object will exist in second")]
    public float TimeOfExistance = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        //start the countdown
        StartCoroutine(CountDownTimer());
    }

    //this is the timer of how long the object remains for
    IEnumerator CountDownTimer()
    {
        //destroy object after given time is up
        yield return new WaitForSeconds(TimeOfExistance);
        Destroy(gameObject);
    }
}
