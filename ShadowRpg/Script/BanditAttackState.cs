using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAttackState : StateMachineBehaviour
{
    Transform shadowTransForm;
    Shadow shadow;
    int target;

    Vector3 vector3;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        shadow = animator.GetComponent<Shadow>();
        shadowTransForm = animator.GetComponent<Transform>();
        if (BattleManager.battleEnemyList.Count > 0)
        {
            //Banditのターゲットはいつも一番後ろにいる敵になる。
            target = BattleManager.battleEnemyList.Count-1;
            //ターゲットの前の位置
            vector3 = new Vector3(BattleManager.battleEnemyList[target].transform.position.x - 0.7f, shadowTransForm.position.y, shadowTransForm.position.z);
            //ターゲットの前に移動する。
            shadowTransForm.position = vector3;
            shadow.targetEnemy = BattleManager.battleEnemyList[target];
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //攻撃が終わると元の場所に戻る。
        vector3 = new Vector3(shadow.battlePosition.position.x, shadowTransForm.position.y, shadowTransForm.position.z);
        shadowTransForm.position = vector3;

    }
}
