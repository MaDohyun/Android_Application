using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowIdleState : StateMachineBehaviour
{
    Transform shadowTransForm;
    Shadow shadow;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shadow = animator.GetComponent<Shadow>();
        shadowTransForm = animator.GetComponent<Transform>();
        shadow.actionState = Shadow.ActionState.Ready;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
            if (Mathf.Abs(shadowTransForm.position.x - shadow.battlePosition.position.x) > 0.1f)
            {
                animator.SetBool("Move", true);
            }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}