using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Shadow
{
    //スキルを使うと"Fear!"というTextが出て、一番前の敵を一番後ろに動かせる。
    public void Skill()
    {
        CreateStateText("Fear!");
        GameManager.instance.SwapEnemy(BattleManager.battleEnemyList,
        targetEnemy.battlePositionNumber - 1, BattleManager.battleEnemyList.Count - 1);

    }
    //スキルのアニメを実行させる。
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

}
