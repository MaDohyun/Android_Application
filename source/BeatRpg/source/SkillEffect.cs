using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : SkillController
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void SkillAction()
    {
        animator.SetTrigger("skillon");
    }
}
