using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackButton : MonoBehaviour
{
    public Skill skill;
    AttackManager atkManager;

    private void Awake()
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
    }
}
