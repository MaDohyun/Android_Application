using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizard : Enemy
{
   [SerializeField] FireBall fireBall;
    [SerializeField] Transform fireBallAppearTrans;

    //FireWizardは攻撃する時fireBallAppearTransにFireBallを生成する。
    public override void Attack()
    {
        fireBall.SetFireBallDamage(DAMAGE);
        Instantiate(fireBall, fireBallAppearTrans);
    }
}
