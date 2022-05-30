using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerCastingState : StateMachineBehaviour
{
   
    Bringer enemy;
    Transform enemyTransform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Bringer>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.actionOn)
        {
            enemy.skillCount -= 1;
            enemy.actionDelay = 0;
        }
        if (enemy.skillCount == 0)
        {
            animator.SetBool("Casting", false);
            
        }
        if (enemyTransform.position.x > enemy.battlePosition.position.x)
        {
            enemyTransform.Translate(Vector2.left * Time.deltaTime * enemy.appearSpeed);
        }
        if (enemyTransform.position.x < enemy.battlePosition.position.x)
        {
            enemyTransform.Translate(Vector2.right * Time.deltaTime * enemy.appearSpeed);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemy.skillCount = 3;
    }
}
