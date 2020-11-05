////////////////
/// Author: Owen Whitehouse
/// Date Created: 11/4/2020
/// Desc: sets health of object to amount, and has change
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour
{
    public int MaximumHealth = 10;
    public int CurrentHealth = 10;
    public bool DestroyAtZero = true;
    public UnityEvent UpUponDeath;

    // Start is called before the first frame update
    void Start()
    {
        if (UponDeath == null)
            UponDeath = new UnityEvent();
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

            if (DestroyAtZero)
            {
                Destroy(gameObject);
            }
        }
    }
}
