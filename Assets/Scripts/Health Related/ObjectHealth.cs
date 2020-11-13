////////////////
/// Author: Owen Whitehouse & Thomas Allen
/// Date Created: 11/5/2020
/// Desc: sets health of object to amount, and has change health function. Also respawns object at 0 hp.
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ObjectHealth : MonoBehaviour
{
    //max health of object
    public int MaximumHealth = 10;
    //current health
    public int CurrentHealth = 10;
    //wether or not to destory the gameoject
    public bool DestroyAtZero;
    //things to do on death
    public UnityEvent UponDeath;

    // Scripts
    PlayerHealthBar player;
    //BossHealthBar boss;
    SoundPlayonEvent sound;

    // Distinguishes health bars
    GameObject thing;

    //respawn script
    public Respawn respawn;


    // Start is called before the first frame update
    void Start()
    {
        if (UponDeath == null)
            UponDeath = new UnityEvent();

        thing = this.gameObject;

        // Gets sound source
        GameObject source = GameObject.Find("Sound Source");
        sound = source.GetComponent<SoundPlayonEvent>();

        // Sets component of Player HB, and runs it for the first time
        GameObject play = GameObject.FindGameObjectWithTag("Player");
        player = play.GetComponent<PlayerHealthBar>();
        player.HealthChange(CurrentHealth, MaximumHealth);

        //unused bit for boss
        /*
        Scene currentScene = SceneManager.GetActiveScene();
        // Gets script off of health bar object, and runs it once
        if (currentScene.buildIndex == 6)
        {
            GameObject enemy = GameObject.Find("Boss Health");
            boss = enemy.GetComponent<BossHealthBar>();
            boss.BarChange();
        }
        */
    }

    public void ChangeHealth(int change)
    {
        // adjusts health based on change
        CurrentHealth += change;


        // If overhealed, sets to max health
        if (CurrentHealth > MaximumHealth)
        {
            CurrentHealth = MaximumHealth;
        }
            
        // if less than 0, handle death
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            UponDeath.Invoke();

            //destroy object
            if (DestroyAtZero)
            {
                if (thing.tag == "Player")
                {
                    Destroy(gameObject, 2);
                    sound.PlaySound("Death");
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            //or respawn object
            else if (gameObject.CompareTag("Player"))
            {
                if (thing.tag == "Player")
                    sound.PlaySound("Death");

                respawn = gameObject.GetComponent<Respawn>();
                respawn.respawn();
                CurrentHealth = MaximumHealth;
            }
        }

        // Detects if current objects tag is player or boss, and changes bar accordingly
        if (thing.tag == "Player")
            player.HealthChange(CurrentHealth, MaximumHealth);
        /*
        else if (thing.tag == "Boss")
            boss.BarChange();
        */
    }
}
