using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDeathState : StateMachineBehaviour
{
    Shadow shadow;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shadow = animator.GetComponent<Shadow>();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            if (Player.instance.battleShadowList[i].gameObject == shadow.gameObject)
            {
                Player.instance.battleShadowList.RemoveAt(i);
            }
        }
        for (int i = 0; i < Player.instance.haveShadowList.Count; i++)
        {
            if (Player.instance.haveShadowList[i].gameObject == shadow.gameObject)
            {
                Player.instance.haveShadowList.RemoveAt(i);
            }
        }
        Destroy(shadow.gameObject);
    }
}
