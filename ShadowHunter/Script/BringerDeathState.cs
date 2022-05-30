using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerDeathState : StateMachineBehaviour
{
    Bringer enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Bringer>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        for (int i = 0; i < BattleManager.battleEnemyList.Count; i++)
        {
            if (BattleManager.battleEnemyList[i].gameObject == enemy.gameObject)
            {
                BattleManager.battleEnemyList.RemoveAt(i);
            }
        }
        if (enemy.castingSkill != null)
        {
            Destroy(enemy.castingSkill.gameObject);
        }
        Destroy(enemy.gameObject);
    }
}
