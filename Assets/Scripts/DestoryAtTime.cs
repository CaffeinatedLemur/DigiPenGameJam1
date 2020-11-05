/***************
* by: Ryan Shepppler
* Writen out by: Turin Thompson
* Date: 10/21/2020
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
        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(TimeOfExistance);
        Destroy(gameObject);
    }
}
