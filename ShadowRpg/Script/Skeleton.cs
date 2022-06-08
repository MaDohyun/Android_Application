using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : Enemy
{
    public bool isSkill = false;

    protected override void Update()
    {
        base.Update();
        //スキルを使っている時actionOnがtrueになると新しく行動する。
        if (actionOn && isSkill)
        {
            isSkill = false;
            this.GetComponent<Animator>().SetBool("Skill", false);
        }
    }
    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < BattleManager.battleEnemyList.Count; i++)
        {
            if (BattleManager.battleEnemyList[i] == this)
            {
                BattleManager.battleEnemyList.Insert(0, this);
                BattleManager.battleEnemyList.RemoveAt(i + 1);
            }
        }

    }
    public override void TakeDamege(float damage)
    {

        //スキルを使っている時攻撃されると一回ブロックする。
        if (isSkill)
        {
            if (HP > 0)
            {
                isSkill = false;
                this.GetComponent<Animator>().SetBool("Skill", false);
                CreateStateText("Block");
            }
        }
        else if (!isSkill)
        {
            if (HP > 0)
            {
                this.GetComponent<Animator>().SetTrigger("Hit");
                HP -= damage * (100 - DEFFENCE) / 100;
                CreateDamageText((int)(damage * (100 - DEFFENCE) / 100));
            }
        }


    }

}