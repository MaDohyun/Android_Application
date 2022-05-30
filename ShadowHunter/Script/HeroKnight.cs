using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroKnight : Shadow
{
    public GameObject protectEffect;

    protected override void Start()
    {
        base.Start();
        protectEffect.SetActive(false);

    }
    
    public void Skill()
    {

        protectEffect.SetActive(true);
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].DEFFENCE += 40;
        }
        Invoke("SkillOff",5.0f);
    }
    public void SkillOff()
    {
        protectEffect.SetActive(false);
       
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].DEFFENCE -= 40;
        }
        }
}
