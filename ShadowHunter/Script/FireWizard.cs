using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizard : Enemy
{
   [SerializeField] FireBall fireBall;
    [SerializeField] Transform fireBallAppearTrans;
    public override void Attack()
    {
        fireBall.SetFireBallDamage(DAMAGE);
        Instantiate(fireBall, fireBallAppearTrans);
    }
}
