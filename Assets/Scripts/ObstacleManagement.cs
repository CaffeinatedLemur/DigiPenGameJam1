/////////////////////////////////
///By: Frank Vanris
///Date: 11/5/2020
///Description: This will be the level loader that will make you go to the next level.
////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManagement : MonoBehaviour
{

    public int ilevelToLoad;
    public string slevelToLoad;


    public bool useIntegerToLoadLevel = false;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if(useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(ilevelToLoad);
        }

        else
        {
            SceneManager.LoadScene(slevelToLoad);
        }
    }
}
