using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    Skill skill;

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
    }

    public void ExcecuteSkill()
    {
        Debug.Log(skill.skillName);
        Debug.Log(skill.damage);
        Debug.Log(skill.apCost);
        Debug.Log(skill.currentCD);
        Debug.Log(skill.skillCD);
    }
}
