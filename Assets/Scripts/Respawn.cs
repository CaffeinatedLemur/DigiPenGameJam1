////////////////
//Name: Thomas Allen
//Script by: Ryan Scheppler
//Date: 11/6/2020
//Description: Repawns player at respawn point when health is at 0
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject RespawnPoint;
    public GameObject player;
    Scene scene;


    public ObjectHealth health;
    public float currenthealth;

    //public Text OnDeathtext;
     
    public void respawn()
    {
        /*
        health = player.GetComponent<ObjectHealth>();
        currenthealth = health.CurrentHealth;

        if (currenthealth <= 0)*/
        Invoke("InvokeRespawn", 2f);
        //OnDeathtext.enabled = true;

    }

    private void InvokeRespawn()
    {
        //gameObject.transform.position = RespawnPoint.transform.position;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        //OnDeathtext.enabled = false;
    }
}
