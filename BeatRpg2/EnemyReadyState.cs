using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReadyState : StateMachineBehaviour
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
        if (PartyMember.Party.Count > 0){
            if (enemy.atkDelay <= 0)
            {
                animator.SetTrigger("Attack");
                enemy.atkDelay = enemy.atkCooltime;
            }
        }
        if (enemy.closecharacter != null)
        {
            if (PartyMember.Party.Count > 0 && Vector2.Distance(enemyTransform.position, enemy.closecharacter.transform.position) > enemy.RANGE)
            {
                animator.SetBool("NotEnemy", false);
                animator.SetBool("Moving", true);
            }
        }
        else if (PartyMember.Party.Count == 0)
        {
            animator.SetBool("NotEnemy", true);
        }
        enemy.changedirection();

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
