////////////////
/// Author: Owen Whitehouse & Thomas Allen
/// Date Created: 11/5/2020
/// Desc: sets health of object to amount, and has change health function. Also respawns object at 0 hp.
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    // Scripts for health bars
    PlayerHealthBar player;
    BossHealthBar boss;

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

        // Sets component of Player HB, and runs it for the first time
        GameObject play = GameObject.FindGameObjectWithTag("Player");
        player = play.GetComponent<PlayerHealthBar>();
        player.HealthChange(CurrentHealth, MaximumHealth);

        // Gets script off of health bar object, and runs it once
        GameObject enemy = GameObject.Find("Boss Health");
        boss = enemy.GetComponent<BossHealthBar>();
        boss.BarChange();
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
                Destroy(gameObject);
            }
            //or respawn object
            else if (gameObject.CompareTag("Player"))
            {
                respawn = gameObject.GetComponent<Respawn>();
                respawn.respawn();
                CurrentHealth = MaximumHealth;
            }
        }

        // Detects if current objects tag is player or boss, and changes bar accordingly
        if (thing.tag == "Player")
            player.HealthChange(CurrentHealth, MaximumHealth);
        else if (thing.tag == "Boss")
            boss.BarChange();
    }
}
