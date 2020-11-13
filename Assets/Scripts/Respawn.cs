////////////////
//Name: Thomas Allen
//Date: 11/6/2020
//Description: Repawns player at respawn point when health is at 0
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Respawn : MonoBehaviour
{
    //player to respawn
    public GameObject player;
    //scene the palyer is in
    Scene scene; 

    //wether or not the player is dead (for input script)
    public bool dead;

    //Health script of the player
    public ObjectHealth health;
    //current health of player from above script
    public float currenthealth;

     
    public void respawn()
    {
      
        Invoke("InvokeRespawn", 1f); //respawn after a delay to let death sound play
        dead = true; 
        

    }

    private void InvokeRespawn()
    {
        scene = SceneManager.GetActiveScene(); //find what current scene inddex the player is on
        SceneManager.LoadScene(scene.buildIndex); //reload that scene
        dead = false; //set player to alive
    }
}
