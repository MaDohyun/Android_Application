using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : StateMachineBehaviour
{

    Transform enemyTransform;
    Enemy enemy;
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
        enemyTransform = animator.GetComponent<Transform>();
        enemy = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        
        if (enemyTransform.position.x > enemy.battlePosition.position.x)
        {
            enemyTransform.Translate(Vector2.left * Time.deltaTime * enemy.appearSpeed);
        }
        if (enemyTransform.position.x < enemy.battlePosition.position.x)
        {
            enemyTransform.Translate(Vector2.right * Time.deltaTime * enemy.appearSpeed);
           
        }
        if (Mathf.Abs(enemyTransform.position.x - enemy.battlePosition.position.x) <= 0.1f)
        {
            animator.SetBool("Move", false);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    

}
