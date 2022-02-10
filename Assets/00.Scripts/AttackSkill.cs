using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkill : MonoBehaviour
{
    public int damage;
    public bool isDamagingSkill = true;
    public int apCost;

    CharacterHealth enemyHealth;
    CharacterHealth playerHealth;

    private void Start()
    {
        enemyHealth = GameObject.Find("BringerOfDeathRig").GetComponent<CharacterHealth>();
        playerHealth = GameObject.Find("WarriorRig").GetComponent<CharacterHealth>();
    }
    public void ExcecuteSkill()
    {
        if(isDamagingSkill)
        {
            enemyHealth.CharacterDamaged(damage);
        }
        else
        {
            playerHealth.CharacterDamaged(damage * -1);
        }
    }
}
