using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerDeathState : StateMachineBehaviour
{
    Bringer enemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Bringer>();
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        for (int i = 0; i < BattleManager.battleEnemyList.Count; i++)
        {
            if (BattleManager.battleEnemyList[i].gameObject == enemy.gameObject)
            {
                BattleManager.battleEnemyList.RemoveAt(i);
            }
        }
        //ボスが倒れるとスキルもなくなる。
        if (enemy.castingSkill != null)
        {
            Destroy(enemy.castingSkill.gameObject);
        }
        Destroy(enemy.gameObject);
    }
}
