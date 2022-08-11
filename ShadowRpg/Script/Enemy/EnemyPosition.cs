using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵やキャラクターはスキルまたは攻撃行動をする時移動するため、攻撃してきた敵がだれもいないところを攻撃する場合がある。
//そのためいくつかのスキルや攻撃はバトル位置を攻撃してバトル位置が敵やキャラクターにダメージを与える。
public class EnemyPosition : MonoBehaviour
{
    [SerializeField] int enemyPositionNumber;

    public void TakeDamage(float damage)
    {
        if (BattleManager.battleEnemyList.Count >= enemyPositionNumber)
        {
            BattleManager.battleEnemyList[enemyPositionNumber - 1].TakeDamege(damage);
        }
    }
}
