using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalKnight : Shadow
{
    public override void TakeDamege(float damage)
    {
        if(actionState == ActionState.Skill)
        {
            if (HP > 0)
            {
                this.GetComponent<Animator>().SetBool("Skill", false);
                CreateStateText("Block");
            }
        }
        else
        {
            base.TakeDamege(damage);
        }
    }
    public override void AttactAnime()
    {
        if (actionState != ActionState.Skill)
        {
            base.AttactAnime();
        }
        else
        {
            animator.SetBool("Skill", false);
            base.AttactAnime();


        }
    }


}
