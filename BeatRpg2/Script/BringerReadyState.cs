using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerReadyState : StateMachineBehaviour
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
        if (PartyMember.Party.Count > 0)
        {
            if (bringer.atkDelay <= 0)
            {
                
                bringeranimator.SetTrigger("Attack");
                bringer.atkDelay = bringer.atkCooltime;
            }
        }
        if (bringer.closecharacter != null)
        {
            if (PartyMember.Party.Count > 0 && Vector2.Distance(bringerTransform.position, bringer.closecharacter.transform.position) > bringer.RANGE)
            {
                
                bringeranimator.SetBool("NotEnemy", false);
                bringeranimator.SetBool("Moving", true);
            }
        }
        else if (PartyMember.Party.Count == 0)
        {
           
            bringeranimator.SetBool("NotEnemy", true);
        }
        bringer.changedirection();

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
