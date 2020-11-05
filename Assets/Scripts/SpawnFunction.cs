/********
* by: Ryan Sheppler
* writen out by: Turin Thompson
* date: 10/22/20
* Brief: this has a function that spawns things usable by the untiy events of other things
* note: grabbed from TopDownGame, but might be adapted
* *******/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFunction : MonoBehaviour
{
    [Tooltip("List of Prefabs to spawn when this function is called by an event.")]
    public GameObject[] ObjectsToSpawn;

    public void Spawn()
    {
        //Loop runs number of time equal to number of items in array
        for (int i = 0; i < ObjectsToSpawn.Length; i++)
        {
            //spawns a object when called, it could be anything
            Instantiate<GameObject>(ObjectsToSpawn[i], transform.position, Quaternion.identity);
        }
    }
}
