using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    CharacterInfo characterInfo;
    public Slider healthBar;

    private void Start()
    {
        characterInfo = new CharacterInfo { characterType = CharacterInfo.CharacterType.Player, maxHealth = 100};
        characterInfo.currentHealth = characterInfo.maxHealth;
        healthBar.maxValue = characterInfo.maxHealth;
        healthBar.value = characterInfo.currentHealth;
    }

    public void PlayerDamaged(Skill skill)
    {
        characterInfo.currentHealth -= skill.damage;
        Mathf.Clamp(characterInfo.currentHealth, 0, characterInfo.maxHealth);
        healthBar.value = characterInfo.currentHealth;
    }


}
