using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : StateMachineBehaviour
{
    Transform enemyTransForm;
    Enemy enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        enemyTransForm = animator.GetComponent<Transform>();
        enemy = animator.GetComponent<Enemy>();
    }
　  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {//普段敵はIdleアニメの状態でバトル位置から離れると位置に戻る。または攻撃アニメに移動する。
        if (enemy.isBattle)
        {
            if (Mathf.Abs(enemyTransForm.position.x - enemy.battlePosition.position.x) > 0.1f)
            {
                animator.SetBool("Move", true);
            }


            if (Player.instance.battleShadowList.Count > 0)
            {
                if (enemy.actionOn)
                {
                    animator.SetTrigger("Attack");
                    enemy.actionDelay = 0;
                }
            }
        }
    }

}
