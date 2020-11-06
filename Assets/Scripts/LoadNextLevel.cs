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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int nextSceneIndex = scene.buildIndex;
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneIndex++);
        }
    }
}
