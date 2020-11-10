// Author: Owen Whitehouse
// Date: 11/10/2020
// Desc: Takes health of boss, and scales a red rectangle to percentage of health

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    Vector3 scale;
    // Script
    ObjectHealth OH;
    // Health floats
    float health, maxHealth;

    void Start()
    {
        // Gets health script from Boss and sets it
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        OH = boss.GetComponent<ObjectHealth>();

        // Sets health first time to start scaling
        health = OH.CurrentHealth;
        maxHealth = OH.MaximumHealth;

        scale = transform.localScale;
    }

    // Changes the scale of the red rectangle "health" upon health change
    // Called from health change script
    public void BarChange()
    {
        // Sets health for equation
        health = OH.CurrentHealth;
        maxHealth = OH.MaximumHealth;

        // Gets the percentage of health left, and scales it up to size
        scale.x = (health / maxHealth) * 335;
        transform.localScale = scale;
    }
}
