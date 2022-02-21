using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackSkill : MonoBehaviour
{
    public RectTransform skillBar;
    public Transform skillTemplate;

    public List<Skill> skillList;


    private void Start()
    {
        skillList = new List<Skill>();

        AddSkill(new Skill
        {
            skillName = Skill.SkillName.AreaAttack,
            damage = 10,
            apCost = 2,
            skillCD = 4,
            currentCD = 0
        });
        AddSkill(new Skill
        {
            skillName = Skill.SkillName.ChainAttack1,
            damage = 12,
            apCost = 1,
            skillCD = 3,
            currentCD = 0
        });
        AddSkill(new Skill
        {
            skillName = Skill.SkillName.ChainAttack2,
            damage = 24,
            apCost = 2,
            skillCD = 3,
            currentCD = 0
        });
        AddSkill(new Skill
        {
            skillName = Skill.SkillName.SelfHeal,
            damage = -10,
            apCost = 1,
            skillCD = 3,
            currentCD = 0
        });
        AddSkill(new Skill
        {
            skillName = Skill.SkillName.AutoAttack,
            damage = 10,
            apCost = 1,
            skillCD = 1,
            currentCD = 0
        });

        RefreshSkillButton();
    }

    public void RefreshSkillButton()
    {
        foreach(Skill skills in skillList)
        {
            Transform skillButton = Instantiate(skillTemplate, skillBar).GetComponent<Transform>();
            skillButton.Find("SkillName").GetComponent<TextMeshProUGUI>().text = skills.skillName.ToString() + " / " + skills.currentCD;
            skillButton.GetComponent<AttackButton>().SetSkill(skills);
        }
    }

    public void AddSkill(Skill skill)
    {
        skillList.Add(skill);
    }
}
