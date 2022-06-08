using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : StateMachineBehaviour
{

    SpriteRenderer enemySprite;
   //攻撃されると色が変わる効果がある。（白い色）
    Color hitColor = new Color(0.8f,0.8f,0.8f,-0.2f);
    Color enemyColor = new Color(1, 1, 1, 1);
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemySprite = animator.GetComponent<SpriteRenderer>();
        enemySprite.material.color += hitColor;
     
    }

     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemySprite.material.color = enemyColor;
    }
}
