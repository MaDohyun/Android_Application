using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai :  Shadow
{
    public override void SkillAnime()
    {
        if (isSelected && actionOn)
        {
            actionDelay = 0;
            actionOn = false;
            skillDelay = skillCooltime;
            skillOn = false;
            animator.SetTrigger("Skill");
            actionState = ActionState.Skill;
        }

    }
    public void Skill()
    {
        float enemytakedamage;
        enemytakedamage = targetEnemy.HP;
        targetEnemy.TakeDamege(DAMAGE*1.5f);
        enemytakedamage -= targetEnemy.HP;
        CreateShadowsVampireText((int)enemytakedamage);
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].HP += enemytakedamage;
        }

    }

    public GameObject VampireText;

    public void CreateShadowsVampireText(int damage)
    {
        for(int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            GameObject Text = Instantiate(VampireText);
            Text.transform.position = Player.instance.battleShadowList[i].TextAppearTransform.position;
            Text.GetComponent<VampireText>().damage = damage;
        }
       
    }
   
}
