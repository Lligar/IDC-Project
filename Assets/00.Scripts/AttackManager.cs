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

    public PlayerAnimation playerAnimation;

    PlayerHealth playerInfo;
    EnemyHealth enemyInfo;

    public Image[] apCounter;

    private void Start()
    {
        maxAP = 7;
        currentAP = maxAP;
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        //enemyInfo = GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>();
        attackSequence = new List<Skill>();
        availableSkills = attackSkill.skillList;
    }

    public void SetEnemyHealth(EnemyHealth enemyHealth)
    {
        this.enemyInfo = enemyHealth;
    }

    public void QueueSkill(Skill skill)
    {
        if (skill.currentCD <= 0 && currentAP >= skill.apCost)
        {
            attackSequence.Add(skill);
            currentAP -= skill.apCost;
            skill.currentCD = skill.skillCD;
            AttackCDApply();
            RefreshAttackInfo();
        }
    }


    public IEnumerator ExcecuteSequence()
    {
        for (int i = 0; i < attackSequence.Count; i++)
        {
            

            ExcecuteSkill(i);
            print("Player uses " + attackSequence[i].skillName + " on Bod, dealing " + attackSequence[i].damage + " damage.");
            // Waiting for attack to finish. Will be changed to animation end later

            playerAnimation.TriggerAnim(attackSequence[i]);

            if (enemyInfo.IsDead())
            {
                enemyInfo.EnemyHealthDeath();
                yield return new WaitForSeconds(1f);
                break;
            }

            yield return new WaitForSeconds(0.25f);

            while (!playerAnimation.CheckIfIdle())
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);
        }


        attackSequence.Clear();
        currentAP = maxAP;

        foreach (Transform attackButton in attackSkill.skillGOList)
        {
            attackButton.GetComponent<AttackButton>().SaveTurnStartCD();
        }

        RefreshAttackInfo();

        if (CheckIfEnemyWiped())
        {
            // 캐릭터 이동 및 캐릭터 생성
            playerAnimation.StartCoroutine("TriggerRun");
        }
        
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

    void AttackCDApply()
    {
        foreach (Skill skill in attackSkill.skillList)
        {
            skill.currentCD -= 1;
        }
        attackSkill.RefreshSkillCD();
    }

    public void ExcecuteButton()
    {
        StartCoroutine("ExcecuteSequence");
    }

    public void CancelButton()
    {
        if (attackSequence.Count > 0)
        {
            /*currentAP += attackSequence[attackSequence.Count - 1].apCost;
            attackSequence.RemoveAt(attackSequence.Count - 1);
            AttackCDApply(false);
            RefreshAttackInfo();*/

            currentAP = 7;
            attackSequence.Clear();
            foreach (Transform attackButton in attackSkill.skillGOList)
            {
                Skill skill = attackButton.GetComponent<AttackButton>().skill;
                skill.currentCD = skill.turnStartCD;
            }
            RefreshAttackInfo();
            attackSkill.RefreshSkillCD();
        }
        else
        {
            print("NO QUEUED SKILL");
        }
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

    bool CheckIfEnemyWiped()
    {
        if(!GameObject.FindGameObjectWithTag("Enemy"))
        {
            print("true");
            return true;
        }
        else
        {
            return false;
        }
    }
}
