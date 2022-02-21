using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    Skill skill;
    PlayerHealth playerInfo;
    EnemyHealth enemyInfo;

    private void Start()
    {
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        enemyInfo = GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>();
    }

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
    }

    public void ExcecuteSkill()
    {
        if(skill.IsDamagingSkill())
        {
            enemyInfo.EnemyDamaged(skill);
        }
        else
        {
            playerInfo.PlayerDamaged(skill);
        }
    }
}
