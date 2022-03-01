using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public SkillName skillName;
    public int damage;
    public int apCost;
    public int skillCD;
    public int currentCD;
    public int turnstartCD;

    public enum SkillName
    {
        AreaAttack,
        ChainAttack1,
        ChainAttack2,
        SelfHeal,
        AutoAttack
    }

    public bool IsDamagingSkill()
    {
        switch(skillName)
        {
            default:
            case SkillName.AreaAttack:
            case SkillName.AutoAttack:
            case SkillName.ChainAttack1:
            case SkillName.ChainAttack2:
                return true;
            case SkillName.SelfHeal:
                return false;
        }
    }
}