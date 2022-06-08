using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : StateMachineBehaviour
{
    Transform enemyTransForm;
    Skeleton enemy;
    int random;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemyTransForm = animator.GetComponent<Transform>();
        enemy = animator.GetComponent<Skeleton>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.isBattle)
        {
            if (Mathf.Abs(enemyTransForm.position.x - enemy.battlePosition.position.x) > 0.1f)
            {
                animator.SetBool("Move", true);
            }


            if (Player.instance.battleShadowList.Count > 0)
            {//アクションが可能になると2分の1の確率で攻撃やスキルを使う。
                if (enemy.actionOn)
                {
                    random = Random.Range(0, 2);
                    if (random == 0)
                    {
                        animator.SetTrigger("Attack");
                        enemy.actionDelay = 0;
                    }
                    else if (random == 1)
                    {
                        animator.SetBool("Skill", true);
                        enemy.isSkill = true;
                        enemy.actionDelay = 0;
                    }

                }
            }
        }
    }

  
}
