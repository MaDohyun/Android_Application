using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerSkillIState : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Casting",true);
    }
}
