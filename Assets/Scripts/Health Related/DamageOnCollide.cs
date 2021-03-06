﻿///////////
///name: Thoams Allen
///Date: 10/21/2020
///desc: Add this to damaging objets like sprites to damage other GameObjects with the health script when they ciillide with the gameobject
///////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollide : MonoBehaviour
{
    [Tooltip("Damage object causes to objects with health")]
    public int damage = 10;
    [Tooltip("Should we destroy this object after it collides?")]
    public bool DestroyOnCollide = true;
    [Tooltip("list of things to do when we collide")]
    public UnityEvent OnCollide = new UnityEvent();
    public GameObject[] ObjectsToSpawn;

    //timer for invul cooldown
    public float timer;
    public float cooldown;
    
    // Sound script
    SoundPlayonEvent sound;

    void Start()
    {
        //get the sound script
        GameObject soundSource = GameObject.Find("Sound Source");

        // Sets up sound
        sound = soundSource.GetComponent<SoundPlayonEvent>();
        //set the invuln cooldown to 1 second
        cooldown = 1;
    }

    public void Update()
    {
        timer += Time.deltaTime; //updte timer
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //get the health compenent
        ObjectHealth otherHealth = collision.gameObject.GetComponent<ObjectHealth>();

        //check to see if invul peroid is over
        if (timer >= cooldown)
        {
            timer = 0;
            //check if otherhealth exists
            if (otherHealth != null)
            {
                //damage the player
                otherHealth.ChangeHealth(-damage);
            }

            for (int i = 0; i < ObjectsToSpawn.Length; ++i)
            {
                //make the on damage sound effect
                Instantiate(ObjectsToSpawn[i], transform.position, Quaternion.identity);
            }
            //unity event setup
            OnCollide.Invoke();
            //destory the damaged thing?
            if (DestroyOnCollide)
                Destroy(gameObject);

            // To help with sound script (Owen Whitehouse)
            if (collision.gameObject.tag == "Player")
                sound.PlaySound("Hurt");
        }
    }
}