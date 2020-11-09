using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShifiter : MonoBehaviour
{
    public GameObject player;
    public GameObject xThreshold;
    public GameObject NegXThreshold;

    public float targetarea;
    public float negtargetarea;
    public float playerX;
    public float threshold;
    public float NegThreshold;

    public Vector3 NextCamPos;
    public Vector3 NextNegCamPos;
    public Vector3 NextThreshPos;
    public Vector3 NextNegThreshPos;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        NextCamPos = gameObject.transform.position;
        targetarea = gameObject.transform.position.x + 20;
        negtargetarea = gameObject.transform.position.x - 20;

    }

    // Update is called once per frame
    void Update()
    {

        playerX = player.transform.position.x;
        threshold = xThreshold.transform.position.x;
        /*
        if (playerX % 10 == 0 && NextCamPos.x != targetarea)
        {
            print("working");

            for (int i = 0; i < 11; i++)
            {
                NextCamPos.x = NextCamPos.x + 1;
                NextThreshPos.x = NextThreshPos.x + 1;
                gameObject.transform.position = NextCamPos;
                xThreshold.transform.position = NextThreshPos;
                if (i == 10)
                    targetarea = gameObject.transform.position.x + 25;
            }
        }
        */
        if (playerX >= threshold && NextCamPos.x != targetarea)
        {
            NextCamPos.x = NextCamPos.x + 1;

            gameObject.transform.position = NextCamPos;
            xThreshold.transform.position = NextThreshPos;
            i++;
            if (i == 14)
            {
                i = 0;
                NextThreshPos.x = NextThreshPos.x + 20;

                targetarea = gameObject.transform.position.x + 20;
            }
        }
        threshold = xThreshold.transform.position.x;


        //-------------------------------------------\

        playerX = player.transform.position.x;
        NegThreshold = NegXThreshold.transform.position.x;
       
        if (playerX <= NegThreshold && NextNegCamPos.x != negtargetarea)
        {
            NextNegCamPos.x = NextNegCamPos.x - 1;

            gameObject.transform.position = NextNegCamPos;
            NegXThreshold.transform.position = NextNegThreshPos;
            i++;
            if (i == 14)
            {
                i = 0;
                NextNegThreshPos.x = NextNegThreshPos.x - 20;

                negtargetarea = gameObject.transform.position.x - 20;
            }
        }
        NegThreshold = NegXThreshold.transform.position.x;



    }
}
