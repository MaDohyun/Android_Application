using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerSkillIAction : StateMachineBehaviour
{
    BringerSkill bringerSkill;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bringerSkill = animator.GetComponent<BringerSkill>();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(bringerSkill.gameObject);
    }
}
