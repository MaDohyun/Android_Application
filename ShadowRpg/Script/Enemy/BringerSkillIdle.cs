using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerSkillIdle : StateMachineBehaviour
{
    BringerSkill bringerSkill;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bringerSkill = animator.GetComponent<BringerSkill>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //ぼすのskillCountによって位置と大きさが変わる。０になると発動される。
        switch (bringerSkill.bringer.skillCount)
        {
            case 2:
                bringerSkill.transform.localScale = new Vector3(15f,7.0f);
                bringerSkill.transform.position = new Vector3(3.39f, 2.14f);
                break;
            case 1:
                bringerSkill.transform.localScale = new Vector3(25.0f,10.0f);
                bringerSkill.transform.position = new Vector3(7.4f,1.36f);

                break;
            case 0:
                animator.SetTrigger("SkillAction");
                break;
                
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
