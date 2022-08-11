using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
// Start is called before the first frame update
{
    //攻撃行動を取った場合の行動
    public virtual void AttackAction()
    {

    }
    //プレイヤーが防御行動を取った場合の行動
    public virtual void PlayerDefenceAction()
    {

    }
    //スキルをする場合の行動
    public virtual void SkillAction()
    {

    }
    //攻撃される場合の行動
public virtual void DamagedAction()
    {

    }
    //死ぬ場合の行動
    public virtual void DeathAction()
    {

    }
    //HPを返す。
    public virtual int getLife()
    {
        return 1;
    }
    //HPを減少させる。
    public virtual int reducelife(int x)
    {
        return 1;
    }
    
    }
