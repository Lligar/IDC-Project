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

    public enum SkillName
    {
        AreaAttack,
        ChainAttack1,
        ChainAttack2,
        SelfHeal,
        AutoAttack
    }
}