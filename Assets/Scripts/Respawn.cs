////////////////
//Name: Thomas Allen
//Script by: Ryan Scheppler
//Date: 11/6/2020
//Description: Repawns player at respawn point when health is at 0
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject RespawnPoint;
    public GameObject player;

    public ObjectHealth health;
    public float currenthealth;

    //public Text OnDeathtext;
     
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void respawn()
    {
        /*
        health = player.GetComponent<ObjectHealth>();
        currenthealth = health.CurrentHealth;

        if (currenthealth <= 0)*/
        Invoke("InvokeRespawn", 0.1f);
        //OnDeathtext.enabled = true;

    }

    private void InvokeRespawn()
    {
        gameObject.transform.position = RespawnPoint.transform.position;
        //OnDeathtext.enabled = false;
    }
}
