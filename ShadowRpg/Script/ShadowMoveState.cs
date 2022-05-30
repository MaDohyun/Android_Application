using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMoveState : StateMachineBehaviour
{
    Transform shadowTransform;
    Shadow shadow;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shadow = animator.GetComponent<Shadow>();
        shadowTransform = animator.GetComponent<Transform>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if (shadowTransform.position.x > shadow.battlePosition.position.x)
        {
            shadowTransform.Translate(Vector2.left * Time.deltaTime * shadow.appearSpeed);
        }
        if (shadowTransform.position.x < shadow.battlePosition.position.x)
        {
            shadowTransform.Translate(Vector2.right * Time.deltaTime * shadow.appearSpeed);

        }
        if (Mathf.Abs(shadowTransform.position.x - shadow.battlePosition.position.x) <= 0.1f)
        {
            animator.SetBool("Move", false);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
