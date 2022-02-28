using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackButton : MonoBehaviour
{
    Skill skill;
    TextMeshProUGUI skillText;
    AttackManager atkManager;


    private void Start()
    {
        atkManager = GameObject.FindGameObjectWithTag("AttackManager").GetComponent<AttackManager>();
        skillText = transform.Find("SkillName").GetComponent<TextMeshProUGUI>();
    }

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
    }

    public void ClickSkill()
    {
        atkManager.QueueSkill(skill);

        skillText.text = skill.skillName + " / " + skill.currentCD.ToString();
    }
}
