using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeatherBoot : Equipment
{
    //LeatherBootは全てのbattleShadowListのキャラクターのアクションタイマーのスピードを1.2倍にする。
    private void Start()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].actionDealySpeed = 1.2f;
        }
    }

  
}
