using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardShadow : Shadow
{
    [SerializeField] FireBallShadow fireBall;
    [SerializeField] Transform fireBallAppearTrans;
    //FireWizardShadowは攻撃する時fireBallAppearTransにFireBallを生成する。
    public override void Attack()
    {
        fireBall.SetFireBallDamage(DAMAGE);
        Instantiate(fireBall, fireBallAppearTrans);
    }
    public override void SkillAnime()
    {
        if (isSelected && actionOn)
        {
            actionDelay = 0;
            actionOn = false;
            skillDelay = skillCooltime;
            skillOn = false;
            animator.SetTrigger("Skill");
            actionState = ActionState.Skill;
        }

    }
}
