using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttackState : StateMachineBehaviour
{
    Transform enemyTransForm;
    Enemy enemy;
    int target;
    Vector3 vector3;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransForm = animator.GetComponent<Transform>();
        if (Player.instance.battleShadowList.Count > 0)
        {
            //Goblinのターゲットはいつも一番後ろのキャラクターになる。
            target = Player.instance.battleShadowList.Count - 1;
            vector3 = new Vector3(Player.instance.battleShadowList[target].transform.position.x + 0.7f, enemyTransForm.position.y, enemyTransForm.position.z);
            enemyTransForm.position = vector3;
            enemy.targetShadow = Player.instance.battleShadowList[target].GetComponent<Shadow>();
        }
       
   }

  　override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        vector3 = new Vector3(enemy.battlePosition.position.x, enemyTransForm.position.y, enemyTransForm.position.z);
        enemyTransForm.position = vector3;

    }

}
