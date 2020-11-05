using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDash : MonoBehaviour
{
    Rigidbody2D body;
    public float speed;
    public float dashSpeed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
