// Author: Owen Whitehouse
// Date: 11/6/2020
// Desc: Uses an array to display health hearts on screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    // Array of hearts
    public Image[] hearts;

    // Sprites for heart containers
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;

    public void HealthChange(int health, int maxHealth)
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            // If i is less than max health, enable the sprite, otherwise disable
            // This makes it so it'll never go over the amount of max health we have
            if (i < (maxHealth / 2))
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }


            if(i < (health / 2))
            {
                // When i is less than health, this shows that we have that 
                hearts[i].sprite = FullHeart;
            }
            else if(health % 2 == 1)
            {
                // When the remainder of health / 2 is 1, this means health is odd
                // This displays a half full heart
                switch(health)
                {
                    // This makes it so each heart is accounted for with each health
                    case 5:
                        hearts[2].sprite = HalfHeart;
                        break;
                    case 3:
                        hearts[2].sprite = EmptyHeart;
                        hearts[1].sprite = HalfHeart;
                        break;
                    case 1:
                        hearts[2].sprite = EmptyHeart;
                        hearts[1].sprite = EmptyHeart;
                        hearts[0].sprite = HalfHeart;
                        break;
                }
            }
            else
            {
                // Otherwise, empty heart
                hearts[i].sprite = EmptyHeart;
            }
        }
    }
}
