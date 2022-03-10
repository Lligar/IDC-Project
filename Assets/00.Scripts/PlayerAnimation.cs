using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    float timer;
    Animator anim;
    public LoopBackground loopBackground;
    public SpawnManager spawnManager;

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

    public IEnumerator TriggerRun()
    {
        anim.SetTrigger("AniRun");
        loopBackground.acceleration = 0f;
        loopBackground.characterIsMoving = true;
        yield return new WaitForSeconds(3f);
        loopBackground.characterIsMoving = false;
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("RunStopped");
        yield return new WaitForSeconds(2f);
        spawnManager.SpawnEnemy();
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
