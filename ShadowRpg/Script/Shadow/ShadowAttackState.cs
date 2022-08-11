using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAttackState : StateMachineBehaviour
{
    Transform shadowTransForm;
    Shadow shadow;
    int target;
    int random;
    Vector3 vector3;
    //キャラクターはAttackアニメになると攻撃範囲にあるランダムな敵をターゲットにする。あるいは攻撃範囲より自分のバトルナンバーが大きい場合は一番前の敵をターゲットにする。
    //攻撃するときはターゲットの前に移動してアニメが終わるとき元のバトル位置に戻る。
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shadow = animator.GetComponent<Shadow>();
        shadowTransForm = animator.GetComponent<Transform>();
        if (shadow.battlePositionNumber - shadow.RANGE > 0)
        {
            target = 0;
            vector3 = new Vector3(BattleManager.battleEnemyList[target].transform.position.x - 0.7f, shadowTransForm.position.y, shadowTransForm.position.z);
            shadowTransForm.position = vector3;
            shadow.targetEnemy = BattleManager.battleEnemyList[target];
        }
        else if (shadow.battlePositionNumber - shadow.RANGE <= 0)
        {
            if (BattleManager.battleEnemyList.Count >= shadow.RANGE - shadow.battlePositionNumber + 1)
            {
                random = Random.Range(0, shadow.RANGE - shadow.battlePositionNumber + 1);
                target = random;

                vector3 = new Vector3(BattleManager.battleEnemyList[target].transform.position.x - 0.7f, shadowTransForm.position.y, shadowTransForm.position.z);
                shadowTransForm.position = vector3;
                shadow.targetEnemy = BattleManager.battleEnemyList[target];
            }
            else if (BattleManager.battleEnemyList.Count < shadow.RANGE - shadow.battlePositionNumber + 1)
            {
                random = Random.Range(0, BattleManager.battleEnemyList.Count - 1);
                target = random;

                vector3 = new Vector3(BattleManager.battleEnemyList[target].transform.position.x - 0.7f, shadowTransForm.position.y, shadowTransForm.position.z);
                shadowTransForm.position = vector3;
                shadow.targetEnemy = BattleManager.battleEnemyList[target];

            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        vector3 = new Vector3(shadow.battlePosition.position.x, shadowTransForm.position.y, shadowTransForm.position.z);
        shadowTransForm.position = vector3;

    }


}
