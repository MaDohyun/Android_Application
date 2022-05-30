using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bringer : Enemy
{
    public bool isSkill = false;
    public BringerSkill bringerSkill;
    [HideInInspector]  public BringerSkill castingSkill;
    public int skillCount;
    SpriteRenderer enemySprite;
    Color hitColor = new Color(1.0f, 0.05f, 0.05f, -0.2f);
    Color enemyColor = new Color(1, 1, 1, 1);
    protected override void Start()
    {
        base.Start();
        enemySprite = GetComponent<SpriteRenderer>();

    }
    public override void TakeDamege(float damage)
    {
        if (isSkill)
        {
            if (HP > 0)
            {
                SkillHitEffectOn();
                Invoke("SkillHitEffectOff",0.3f);
                HP -= damage * (100 - DEFFENCE) / 100 *2;
                CreateDamageText((int)(damage * (100 - DEFFENCE) / 100) * 2);
            }
        }
        else
        {
            if (HP > 0)
            {
                animator.SetTrigger("Hit");
                HP -= damage * (100 - DEFFENCE) / 100;
                CreateDamageText((int)(damage * (100 - DEFFENCE) / 100));
            }
        }
       
    }
    public void CreateSkill()
    {
        castingSkill = Instantiate(bringerSkill);
        castingSkill.SetBringer(this);
        animator.SetBool("Casting",true);

    }

    public void SkillHitEffectOn()
    {
        enemySprite.material.color += hitColor;
    }
    public void SkillHitEffectOff()
    {
        enemySprite.material.color = enemyColor;

    }
}
