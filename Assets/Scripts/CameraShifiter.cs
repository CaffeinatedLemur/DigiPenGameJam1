using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShifiter : MonoBehaviour
{
    public GameObject player;
    public GameObject xThreshold;

    public float targetarea;
    public float playerX;
    public float threshold;

    public Vector3 NextCamPos;

    // Start is called before the first frame update
    void Start()
    {
        NextCamPos = gameObject.transform.position;
        targetarea = gameObject.transform.position.x + 25;

    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        threshold = xThreshold.transform.position.x;
        if (playerX >= threshold && NextCamPos.x != targetarea)
        {
            print("working");
            NextCamPos.x = NextCamPos.x + 1;
            gameObject.transform.position = NextCamPos;
            
        }
        
    }
}
