using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    public bool isSkill = false;
    public override void Attack()
    {
        if (!isSkill)
        {
            targetShadow.TakeDamege(DAMAGE);
        }
        else
        {
            targetShadow.TakeDamege(DAMAGE);
            targetShadow.actionDelay = 0;
            targetShadow.actionOn = false;
            isSkill = false;
            targetShadow.CreateStateText("-Action");
        }

    }
}
