using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterCameraShifter : MonoBehaviour
{
    public GameObject player;

    public float PlayerPos;
    public float PosThresh;

    public float NegThresh;

    public Vector3 Move;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = player.transform.position.x;
        PosThresh = PlayerPos + 10;
        NegThresh = PlayerPos - 10;

        Move.x = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        PlayerPos = player.transform.position.x;
        
        if (PlayerPos >= PosThresh)
        {
            PosThresh += 20;
            NegThresh += 20;
            Move.x += 20;
            gameObject.transform.position = Move;
            
        }

        if (PlayerPos <= NegThresh)
        {
            NegThresh -= 20;
            PosThresh -= 20;
            Move.x -= 20;
            gameObject.transform.position = Move;
            
        }



    }
}
