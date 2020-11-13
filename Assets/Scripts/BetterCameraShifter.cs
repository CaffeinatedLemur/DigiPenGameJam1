//////////////
///Name: Thomas Allen
///Date: 11/12/2020
///desc: Moves camera when player moves beyond a specfied boundry to create a slideshow-like effect
/////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterCameraShifter : MonoBehaviour
{
    //player
    public GameObject player;
    //player's position
    public float PlayerPos;
    //positive X movement threshold
    public float PosThresh;
    //negative X movement threshold
    public float NegThresh;

    //how mcuh to mvoe the camera and thresholds by
    public float ShiftValue;

    //Movement vector
    public Vector3 Move;
    // Start is called before the first frame update
    void Start()
    {
        //get starting positition and thresholds
        PlayerPos = player.transform.position.x;
        PosThresh = PlayerPos + ShiftValue;
        NegThresh = PlayerPos - ShiftValue;

        //set the vecotr X to 0
        Move.x = 0;
    }

    // Update is called once per frame
    void Update()
    {
       //update player position
        PlayerPos = player.transform.position.x;
        
        //check if the player is beyonf the boundry
        if (PlayerPos >= PosThresh)
        {
            //update thresholds
            PosThresh += ShiftValue;
            NegThresh += ShiftValue;
            //update vector
            Move.x += ShiftValue;
            //mover camera
            gameObject.transform.position = Move;
            
        }

        //inverse of above method.  Move backwards instead of forwards.
        if (PlayerPos <= NegThresh)
        {
            NegThresh -= ShiftValue;
            PosThresh -= ShiftValue;
            Move.x -= ShiftValue;
            gameObject.transform.position = Move;
            
        }



    }
}
