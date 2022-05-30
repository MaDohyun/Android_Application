using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeatherBoot : Equipment
{
    

    private void Start()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].actionDealySpeed = 1.2f;
        }
    }

  
}
