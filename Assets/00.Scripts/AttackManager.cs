using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public List<Skill> attackSequence;
    public int maxAP;
    public int currentAP;
    PlayerHealth playerInfo;
    EnemyHealth enemyInfo;

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
        attackSequence.Add(skill);
    }

    public void ExcecuteButton()
    {
        StartCoroutine("ExcecuteSequence");
    }

    public void CancelButton()
    {
        if (attackSequence.Count > 0)
        {
            attackSequence.RemoveAt(attackSequence.Count - 1);
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
