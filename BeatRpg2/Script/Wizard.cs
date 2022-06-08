using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    
  
    public void WizardAttrack()
    {
        if (EnemyList.enemylist.Count > 0)
        {
            base.Attack();
            base.boxpos.gameObject.SetActive(false);
        }
    }
    public void WizardEffectOn()
    {
        if (EnemyList.enemylist.Count > 0)
        {
            base.boxpos.transform.position = base.closeenemy.transform.position;
            base.boxpos.gameObject.SetActive(true);
        }
    }
}
