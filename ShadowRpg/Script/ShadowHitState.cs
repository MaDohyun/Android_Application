using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowHitState : StateMachineBehaviour
{
    SpriteRenderer shadowSprite;

    Color hitColor = new Color(0.8f, 0.8f, 0.8f, -0.2f);
    Color shadowColor = new Color(1, 1, 1, 1);
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        shadowSprite = animator.GetComponent<SpriteRenderer>();
        shadowSprite.material.color += hitColor;
       
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shadowSprite.material.color = shadowColor;
    }
}
