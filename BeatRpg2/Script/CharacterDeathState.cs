using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDeathState : StateMachineBehaviour
{
    Character character;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        character = animator.GetComponent<Character>();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0; i < PartyMember.Party.Count; i++)
        {
            if (PartyMember.Party[i].gameObject == character.gameObject)
            {
                PartyMember.Party.RemoveAt(i);
            }
        }
        Destroy(character.gameObject) ;
    }
}