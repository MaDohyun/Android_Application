using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeatherHelmet : Equipment
{
    private void Start()
    {
        //LeatherHelmetは全ての敵のダメージを0.7倍にする。
        for (int i = 0; i < BattleManager.battleEnemyList.Count; i++)
        {
            BattleManager.battleEnemyList[i].DAMAGE = BattleManager.battleEnemyList[i].DAMAGE * 0.7f;
        }
    }
}
