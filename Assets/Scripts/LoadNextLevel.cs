////////////////
//Name: Thomas Allen
//Script by: Ryan Scheppler
//Date: 11/6/2020
//Description: Loads next level in build order
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
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("Detects collisions");
        int nextSceneIndex = scene.buildIndex;
        nextSceneIndex = nextSceneIndex + 1;
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
