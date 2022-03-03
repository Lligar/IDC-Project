using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;
    bool isDead;

    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void DeadAnimation()
    {
        anim.SetTrigger("IsDead");
        StartCoroutine("DeadSequence");
    }

    IEnumerator DeadSequence()
    {
        yield return null;
        while (anim.GetCurrentAnimatorStateInfo(0).IsName("IsDead"))
        {
            yield return null;
        }
    }

    public void TriggerAnim(Skill skill)
    {
        anim.SetTrigger("Ani" + skill.skillName);
    }
}
