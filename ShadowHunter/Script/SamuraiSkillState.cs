using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiSkillState : StateMachineBehaviour
{
    Transform shadowTransForm;
    Shadow shadow;
    int target;

    Vector3 vector3;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        shadow = animator.GetComponent<Shadow>();
        shadowTransForm = animator.GetComponent<Transform>();
        if (BattleManager.battleEnemyList.Count > 0)
        {
            target = 0;
            vector3 = new Vector3(BattleManager.battleEnemyList[target].transform.position.x - 0.7f, shadowTransForm.position.y, shadowTransForm.position.z);
            shadowTransForm.position = vector3;
            shadow.targetEnemy = BattleManager.battleEnemyList[target];
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        vector3 = new Vector3(shadow.battlePosition.position.x, shadowTransForm.position.y, shadowTransForm.position.z);
        shadowTransForm.position = vector3;

    }
}
