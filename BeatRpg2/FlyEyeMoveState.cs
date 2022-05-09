using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeMoveState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (PartyMember.Party.Count > 0 && Vector2.Distance(enemyTransform.position, enemy.closecharacter.transform.position) > enemy.RANGE)
        {
            enemyTransform.transform.position = Vector2.MoveTowards(enemyTransform.transform.position,enemy.closecharacter.transform.position, Time.deltaTime * enemy.enemyspeed);
            
            // enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, enemy.closecharacter.transform.position, Time.deltaTime);
        }
        else if (PartyMember.Party.Count > 0 && Vector2.Distance(enemyTransform.position, enemy.closecharacter.transform.position) <= enemy.RANGE)
        {
            animator.SetBool("Moving", false);
            animator.SetBool("NotEnemy", false);
        }
        else if (PartyMember.Party.Count == 0)
        {
            animator.SetBool("Moving", false);
            animator.SetBool("NotEnemy", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}