﻿// Author: Owen Whitehouse
// Date: 11/8/2020
// Desc: A short script to play a sound upon an event, a callable function for other scripts to use

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayonEvent : MonoBehaviour
{
    // Audio source, clips, and volume control
    public AudioSource source;
    public static AudioClip dash, hurt, death, jump;
    public float volume = 0.5f;
    public GameObject player;

    void Start()
    {
        // Sets sound to an AudioSource
        source = GetComponent<AudioSource>();

        // Gets sounds from folder
        dash = Resources.Load<AudioClip>("Dash");
        hurt = Resources.Load<AudioClip>("Hurt");
        death = Resources.Load<AudioClip>("Death");
        jump = Resources.Load<AudioClip>("Jump");

        if (player == null)
            player = GameObject.FindWithTag("Player");
    }

    // Public function to call from other scripts
    public void PlaySound(string sound)
    {
        // Allows you to choose which sound to play from list (expandable list)
        switch (sound)
        {
            case "Hurt":
               // Plays hurt sound
               source.PlayOneShot(hurt, volume);
                break;
            case "Dash":
                // Plays dash sound
                source.PlayOneShot(dash, volume);
                break;
            case "Death":
                // Plays death sound
                source.PlayOneShot(death, volume);
                break;
            case "Jump":
                // Plays jump sound
                source.PlayOneShot(jump, volume);
                break;
        }
    }
}
