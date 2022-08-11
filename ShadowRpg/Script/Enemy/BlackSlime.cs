using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackSlime : Enemy
{//現在スキルを使っているかどうか
    public bool isSkill = false;

    public override void Attack()
    {
        if (!isSkill)
        {
            targetShadow.TakeDamege(DAMAGE);
        }
        //スキルを使っている場合、ブラックスライムは一番前にあるキャラクターを一番後ろに動かせる。
        else if (isSkill)
        {
              CreateStateText("Fear!");
            GameManager.instance.SwapShadow(Player.instance.battleShadowList,
            targetShadow.battlePositionNumber - 1, Player.instance.battleShadowList.Count - 1);
            isSkill = false;
        }
        
    }
}