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
    public int MaxHealth = 6;
    public int CurHealth = 6;
    public bool DestroyAtZero = true;
    public UnityEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        if (OnDeath == null)
            OnDeath = new UnityEvent();
    }

    public void ChangeHealth(int change)
    {
        // adjusts health based on change
        CurHealth += change;

        // If overhealed, sets to max health
        if (CurHealth > MaxHealth)
            CurHealth = MaxHealth;

        // if less than 0, handle death
        if (CurHealth <= 0)
        {
            CurHealth = 0;
            OnDeath.Invoke();

            if (DestroyAtZero)
            {
                Destroy(gameObject);
            }
        }
    }
}
