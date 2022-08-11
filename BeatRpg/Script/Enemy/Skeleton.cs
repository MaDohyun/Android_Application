using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public int life;
    public int damage;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void DamagedAction()
    {
        reducelife(PlayerController.damage);
        if (EnemyGenerator.EnemyList[0].getLife() <= 0)
        {
            DeathAction();
            EnemyGenerator.EnemyList.RemoveAt(0);
        }
       
    }
    public override void DeathAction()
    {
        animator.SetTrigger("death");
        Destroy(this.gameObject,0.5f);
    }
    public override void PlayerDefenceAction()
    {
        animator.SetTrigger("attack");
    }
    public override void AttackAction()
    {
        animator.SetTrigger("attack");
        if (PlayerController.life > 0)
        {
            PlayerController.life -= damage;
        }
    }
   
    public override int reducelife(int x)
    {
        life = life - x;
        return life;
    }
    public override int getLife()
    {
        return life;
    }
}
