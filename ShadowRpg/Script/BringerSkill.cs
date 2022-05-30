using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerSkill : MonoBehaviour
{
  [HideInInspector]public Bringer bringer;
    float damage;
    private void Start()
    {
        damage = bringer.DAMAGE * 1.5f;
    }
    
    public void SetBringer(Bringer bringer)
    {
        this.bringer = bringer;
    }

    public void Attack(float damage)
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].TakeDamege(damage);
        }
    }
    
}
