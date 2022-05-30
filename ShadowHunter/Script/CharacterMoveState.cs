using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveState : StateMachineBehaviour
{
    Transform characterTransform;
    Character character;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        character = animator.GetComponent<Character>();
        characterTransform = animator.GetComponent<Transform>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (EnemyList.enemylist.Count > 0 && Vector2.Distance(characterTransform.position, character.closeenemy.transform.position) > character.RANGE)
        {
            characterTransform.Translate(Vector2.right * Time.deltaTime * character.characterspeed);
            // enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, enemy.closecharacter.transform.position, Time.deltaTime);
        }
        else if (EnemyList.enemylist.Count > 0 && Vector2.Distance(characterTransform.position, character.closeenemy.transform.position) <= character.RANGE)
        {
            animator.SetBool("Moving", false);
            animator.SetBool("NotEnemy", false);
        }
        else if (EnemyList.enemylist.Count == 0)
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
