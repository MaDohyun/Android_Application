using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReadyState : StateMachineBehaviour
{
    Transform characterTransform;
    Character character;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        character = animator.GetComponent<Character>();
        characterTransform = animator.GetComponent<Transform>();
        if (character.HP <= 0)
        {
            animator.SetBool("Death", true);

        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        if(EnemyList.enemylist.Count > 0){
            if (character.atkDelay <= 0)
            {
                animator.SetTrigger("Attack");
                character.atkDelay = character.atkCooltime;
            }
        }
        if (character.closeenemy != null)
        {
            if (EnemyList.enemylist.Count > 0 && Vector2.Distance(characterTransform.position, character.closeenemy.transform.position) >character.RANGE)
            {
                animator.SetBool("NotEnemy", false);
                animator.SetBool("Moving", true);
            }
        }
            if (EnemyList.enemylist.Count == 0)
        {
            animator.SetBool("NotEnemy", true);
        }
        character.changedirection();

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
