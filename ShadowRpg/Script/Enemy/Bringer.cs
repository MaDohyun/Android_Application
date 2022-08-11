using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボスモンスタークラス
//ボスモンスターはスキルを使うと長い時間じっとした後スキルを発動させる。

public class Bringer : Enemy
{
    public bool isSkill = false;
    public BringerSkill bringerSkill;
    //スキルのクラス
    [HideInInspector]  public BringerSkill castingSkill;
    //スキルカウンターが0になるとスキルが発動される。
    public int skillCount;
    SpriteRenderer enemySprite;
    //スキルを使うときに攻撃された場合の色（レッド）
    Color hitColor = new Color(1.0f, 0.05f, 0.05f, -0.2f);
    Color enemyColor = new Color(1, 1, 1, 1);
    protected override void Start()
    {
        base.Start();
        enemySprite = GetComponent<SpriteRenderer>();

    }

    public override void TakeDamege(float damage)
    {
        //スキルを使っている際にダメージを受けると2倍になる。
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
    //スキルを使うとBringerSkillのオブジェクトを生成してCastingの状態に入る。
    public void CreateSkill()
    {
        castingSkill = Instantiate(bringerSkill);
        castingSkill.SetBringer(this);
        animator.SetBool("Casting",true);
    }
    //スキルを使ううちに攻撃されると赤くなる効果
    public void SkillHitEffectOn()
    {
        enemySprite.material.color += hitColor;
    }
    //元の色に戻る。
    public void SkillHitEffectOff()
    {
        enemySprite.material.color = enemyColor;

    }
}
