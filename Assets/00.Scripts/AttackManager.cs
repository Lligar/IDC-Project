using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public List<Skill> attackSequence;
    public List<Skill> availableSkills;
    public AttackSkill attackSkill;
    public int maxAP;
    public int currentAP;

    PlayerHealth playerInfo;
    EnemyHealth enemyInfo;

    

    public Image[] apCounter;

    private void Start()
    {
        maxAP = 7;
        currentAP = maxAP;
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        enemyInfo = GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>();
        attackSequence = new List<Skill>();
        availableSkills = attackSkill.skillList;
    }




    public void QueueSkill(Skill skill)
    {
        if (skill.currentCD <= 0 && currentAP >= skill.apCost)
        {
            attackSequence.Add(skill);
            currentAP -= skill.apCost;
            skill.currentCD = skill.skillCD;
            AttackCDApply(true);
            RefreshAttackInfo();
        }
    }
    public void CancelButton()
    {
        if (attackSequence.Count > 0)
        {
            currentAP += attackSequence[attackSequence.Count - 1].apCost;
            attackSequence.RemoveAt(attackSequence.Count - 1);
            AttackCDApply(false);
            RefreshAttackInfo();
        }
        else
        {
            print("NO QUEUED SKILL");
        }
    }

    public IEnumerator ExcecuteSequence()
    {
        for (int i = 0; i < attackSequence.Count; i++)
        {
            ExcecuteSkill(i);
            print("Player uses " + attackSequence[i].skillName + " on Bod, dealing " + attackSequence[i].damage + " damage.");
            // Waiting for attack to finish. Will be changed to animation end later
            yield return new WaitForSeconds(1.5f);
        }
        attackSequence.Clear();
        currentAP = maxAP;
        RefreshAttackInfo();
    }
    void RefreshAttackInfo()
    {
        for (int i = 0; i < apCounter.Length; i++)
        {
            if (i >= currentAP)
            {
                apCounter[i].color = Color.white;
            }
            else
            {
                apCounter[i].color = new Color32(0, 215, 255, 255);
            }
        }
    }

    void AttackCDApply(bool isAttackQueue)
    {
        if(isAttackQueue)
        {
            foreach (Skill skill in attackSkill.skillList)
            {
                skill.currentCD -= 1;
            }
            attackSkill.RefreshSkillCD();
        }
        else
        {
            foreach (Skill skill in attackSkill.skillList)
            {
                    skill.currentCD += 1;

                if(skill.currentCD == skill.skillCD)
                {
                    skill.currentCD = -10;
                }
            }
            attackSkill.RefreshSkillCD();
        }
    }

    public void ExcecuteButton()
    {
        StartCoroutine("ExcecuteSequence");
    }

    void ExcecuteSkill(int i)
    {
        if (attackSequence[i].IsDamagingSkill())
        {
            enemyInfo.EnemyDamaged(attackSequence[i]);
        }
        else
        {
            playerInfo.PlayerDamaged(attackSequence[i]);
        }
    }
}
