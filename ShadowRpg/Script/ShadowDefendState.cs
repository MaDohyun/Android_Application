using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDefendState : StateMachineBehaviour
{
    Transform shadowTransform;
    Shadow shadow;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        shadow = animator.GetComponent<Shadow>();
        shadowTransform = animator.GetComponent<Transform>();
    }
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
    }
        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
