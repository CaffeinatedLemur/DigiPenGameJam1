////////////////
//Name: Thomas Allen
//Script by: Ryan Scheppler
//Date: 11/6/2020
//Description: Loads next level in when button is pressed
////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
