using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{
    public List<Skill> attackSequence;
    public AttackSkill attackSkill;
    public int maxAP;
    public int currentAP;
    PlayerHealth playerInfo;
    EnemyHealth enemyInfo;

    

    public Image[] apCounter;
    //00D7FF

    private void Start()
    {
        maxAP = 7;
        currentAP = maxAP;
        playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        enemyInfo = GameObject.FindWithTag("Enemy").GetComponent<EnemyHealth>();
        attackSequence = new List<Skill>();
    }

    public void QueueSkill(Skill skill)
    {
        if (skill.currentCD == 0 && currentAP >= skill.apCost)
        {
            attackSequence.Add(skill);
            currentAP -= skill.apCost;
            RefreshAPVisual();
        }
    }

    public void ExcecuteButton()
    {
        StartCoroutine("ExcecuteSequence");
    }

    public void CancelButton()
    {
        if (attackSequence.Count > 0)
        {
            currentAP += attackSequence[attackSequence.Count - 1].apCost;
            attackSequence.RemoveAt(attackSequence.Count - 1);
            RefreshAPVisual();
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
        print(attackSequence.Count);
        currentAP = maxAP;
        RefreshAPVisual();
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
    void RefreshAPVisual()
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
            skill.currentCD = Mathf.Clamp(skill.currentCD - 1, 0, skill.skillCD);
        }
    }
}
