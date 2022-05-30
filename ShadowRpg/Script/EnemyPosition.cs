using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
