using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//敵やキャラクターはスキルまたは攻撃行動をする時移動するため、攻撃してきた敵がだれもいないところを攻撃する場合がある。
//そのためいくつかのスキルや攻撃はバトル位置を攻撃してバトル位置が敵やキャラクターにダメージを与える。
public class ShadowPosition : MonoBehaviour
{
    [SerializeField] int shadowPositionNumber;

    public void TakeDamage(float damage)
    {
        if(Player.instance.battleShadowList.Count >= shadowPositionNumber)
        {
            Player.instance.battleShadowList[shadowPositionNumber - 1].TakeDamege(damage);
        }
    }
}
