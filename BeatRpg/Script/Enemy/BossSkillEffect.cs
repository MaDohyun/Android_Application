using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillEffect : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    //スキルの準備を終えてスキルを発動させる。
    public void SkillAction()
    {
        animator.SetTrigger("skillon");
    }
}
