using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void TriggerAnim(Skill skill)
    {
        anim.SetTrigger("Ani" + skill.skillName);
    }


}
