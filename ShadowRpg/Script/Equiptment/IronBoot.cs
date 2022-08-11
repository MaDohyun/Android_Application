using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBoot : Equipment
{
    //IronBootはbattleShadowListの０番目のキャラクターのアクションタイマーのスピードを1.5倍にする。
    private void Start()
    {
      
            Player.instance.battleShadowList[0].actionDealySpeed = 1.5f;
       
    }


}
