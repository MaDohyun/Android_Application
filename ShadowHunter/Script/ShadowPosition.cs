using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
