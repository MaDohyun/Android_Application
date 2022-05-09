using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bringer : Enemy
{
    
    public void BringerAttrack()
    {

        if (EnemyList.enemylist.Count > 0)
        {
            base.Attack();
            base.boxpos.gameObject.SetActive(false);
        }
    }
    public void BringerEffectOn()
    {
        if (EnemyList.enemylist.Count > 0)
        {
            base.boxpos.transform.position = base.closecharacter.transform.position;
            base.boxpos.gameObject.SetActive(true);
        }
    }

   
}
