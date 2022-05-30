using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackSlime : Enemy
{
    public bool isSkill = false;
    public override void Attack()
    {
        if (!isSkill)
        {
            targetShadow.TakeDamege(DAMAGE);
        }
        else if (isSkill)
        {
              CreateStateText("Fear!");
            GameManager.instance.SwapShadow(Player.instance.battleShadowList,
            targetShadow.battlePositionNumber - 1, Player.instance.battleShadowList.Count - 1);
            isSkill = false;
        }
        
    }
}