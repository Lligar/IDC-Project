using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider healthBar;

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.value = maxHealth;
    }


    public void CharacterDamaged(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
    }
}
