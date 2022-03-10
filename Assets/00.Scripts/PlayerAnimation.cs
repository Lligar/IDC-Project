using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    float timer;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(-10f, -1.5f);
        anim = transform.GetChild(0).GetComponent<Animator>();
        StartCoroutine("StartMovement");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartMovement()
    {
        while (timer < 0.1f)
        {
            if (timer > 0.025f)
            {
                anim.SetTrigger("RunStopped");
            }
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, -5f, timer), -1.5f, 0f);
            timer += Time.deltaTime * 0.075f;
            yield return null;
        }
        anim.ResetTrigger("RunStopped");
    }

    public void TriggerAnim(Skill skill)
    {
        anim.SetTrigger("Ani" + skill.skillName);
    }

    public void TriggerRun()
    {
        anim.SetTrigger("AniRun");
    }

    public bool CheckIfIdle()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return true;
        }
        else { return false; }
    }
}
