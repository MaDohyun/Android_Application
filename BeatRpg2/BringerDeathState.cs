using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerDeathState : StateMachineBehaviour
{
    Transform bringerTransform;

    Bringer bringer;

    BringerController bringerController;
    Animator bringeranimator;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bringer = animator.GetComponent<BringerController>().bringer.GetComponent<Bringer>();
        bringerController = animator.GetComponent<BringerController>();
        bringeranimator = bringerController.GetComponent<Animator>();

        bringerTransform = bringer.GetComponent<Transform>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0; i < EnemyList.enemylist.Count; i++)
        {
            if (EnemyList.enemylist[i].gameObject == bringer.gameObject)
            {
                EnemyList.enemylist.RemoveAt(i);
            }
        }
        Destroy(bringer.gameObject);
    }
}