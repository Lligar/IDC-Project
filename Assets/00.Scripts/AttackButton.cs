using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    Skill skill;
    AttackManager atkManager;

    private void Start()
    {
        atkManager = GameObject.FindGameObjectWithTag("AttackManager").GetComponent<AttackManager>();
    }

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
    }

    public void ClickSkill()
    {
        atkManager.QueueSkill(skill);
        for (int i = 0; i < atkManager.attackSequence.Count; i ++)
        {
            print(atkManager.attackSequence[i].skillName);
        }
    }
}
