// Author: Owen Whitehouse
// Date: 11/8/2020
// Desc: A short script to play a sound upon an event, a callable function for other scripts to use

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayonEvent : MonoBehaviour
{
    // Audio source, clips, and volume control
    public AudioSource source;
    public static AudioClip dash, hurt;
    public float volume = 0.5f;
    private GameObject player;

    void Start()
    {
        // Sets sound to an AudioSource
        source = GetComponent<AudioSource>();

        dash = Resources.Load<AudioClip>("Dash");
        hurt = Resources.Load<AudioClip>("Hurt");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Public function to call from other scripts
    public void PlaySound(int soundNum)
    {
        // Allows you to choose which sound to play from list (expandable list)
        switch (soundNum)
        {
            case 1:
                // If it's tagged player, play hurt sound
                if (player)
                {
                    // Plays hurt sound
                    source.PlayOneShot(hurt, volume);
                }
                break;
            case 2:
                // Plays dash sound
                source.PlayOneShot(dash, volume);
                break;
        }
    }
}
