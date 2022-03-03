using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    CharacterInfo characterInfo;
    EnemyAnimation enemyAnimation;
    public Slider healthBar;

    private void Start()
    {
        enemyAnimation = GetComponent<EnemyAnimation>();
        characterInfo = new CharacterInfo { characterType = CharacterInfo.CharacterType.Enemy, maxHealth = 10 };
        characterInfo.currentHealth = characterInfo.maxHealth;
        healthBar.maxValue = characterInfo.maxHealth;
        healthBar.value = characterInfo.currentHealth;
    }

    public void EnemyDamaged(Skill skill)
    {
        characterInfo.currentHealth -= skill.damage;
        Mathf.Clamp(characterInfo.currentHealth, 0, characterInfo.maxHealth);
        healthBar.value = characterInfo.currentHealth;
    }

    public void EnemyHealthDeath()
    {
        enemyAnimation.DeadAnimation();
    }

    public bool IsDead()
    {
        if (characterInfo.currentHealth <= 0)
        {
            return true;
        }
        else { return false; }
    }
}
