////////////////
//Name: Thomas Allen
//Date: 11/6/2020
//Desc: Loads next level in build order.
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    //current scene
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene(); //find the active scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //triggers on collition with an Trigger collider
    public void OnTriggerEnter2D(Collider2D collision)
    {
        int nextSceneIndex = scene.buildIndex; //find the current scene's index
        nextSceneIndex = nextSceneIndex + 1; //find the next scene's index
        if (collision.gameObject.CompareTag("Player")) //make sure it is the player before loading
        {
            SceneManager.LoadScene(nextSceneIndex); //loads the next level
        }
    }
}
