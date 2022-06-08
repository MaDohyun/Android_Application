using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerMoveState : StateMachineBehaviour
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

        if (PartyMember.Party.Count > 0 && Vector2.Distance(bringerTransform.position, bringer.closecharacter.transform.position) > bringer.RANGE)
        {
            bringerTransform.Translate(Vector2.left * Time.deltaTime * bringer.enemyspeed);
            // bringerTransform.position = Vector2.MoveTowards(bringerTransform.position, bringer.closecharacter.transform.position, Time.deltaTime);
        }
        else if (PartyMember.Party.Count > 0 && Vector2.Distance(bringerTransform.position, bringer.closecharacter.transform.position) <= bringer.RANGE)
        {
            bringeranimator.SetBool("Moving", false);
            bringeranimator.SetBool("NotEnemy", false);
        }
        else if (PartyMember.Party.Count == 0)
        {
     
            bringeranimator.SetBool("Moving", false);
            bringeranimator.SetBool("NotEnemy", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
