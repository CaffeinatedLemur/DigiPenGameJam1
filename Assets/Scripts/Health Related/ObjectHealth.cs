////////////////
/// Author: Owen Whitehouse & Thomas Allen
/// Date Created: 11/5/2020
/// Desc: sets health of object to amount, and has change health functrion. Also respawns object at 0 hp.
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

    PlayerHealthBar myPHB;

    //respawn script
    public Respawn respawn;


    // Start is called before the first frame update
    void Start()
    {
        if (UponDeath == null)
            UponDeath = new UnityEvent();

        myPHB = GetComponent<PlayerHealthBar>();
        myPHB.HealthChange(CurrentHealth, MaximumHealth);

        print("Max health: " + MaximumHealth);
        print("Current Health: " + CurrentHealth);
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
        
        print("CurHealth: " + CurrentHealth);
        myPHB.HealthChange(CurrentHealth, MaximumHealth);
    }
}
