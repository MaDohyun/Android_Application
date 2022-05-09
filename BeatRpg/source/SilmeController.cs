using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilmeController : EnemyController
{
    public int life;
    public int damage;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void DamagedAction()
    { 
        reducelife(PlayerController.damage);
        animator.SetTrigger("bomb");
        Invoke("Bomb", 0.3f);
        Destroy(this.gameObject, 0.3f);
        if (EnemyGenerator.EnemyList[0].getLife() <= 0)
        {
            DeathAction();
            EnemyGenerator.EnemyList.RemoveAt(0);
        }
    }
    public override void DeathAction()
    {
        animator.SetTrigger("death");
        Destroy(this.gameObject, 0.5f);
    }
    public override void DefenceAction()
    {
        animator.SetTrigger("bomb");
        EnemyGenerator.EnemyList.RemoveAt(0);
        Destroy(this.gameObject, 0.3f);
    }
    public override void AttackAction()
    {
        animator.SetTrigger("bomb");
        Invoke("Bomb", 0.3f);
        Destroy(this.gameObject, 0.3f);
    }
    public override void SkillAction()
    {
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
    public void Bomb()
    {
        EnemyGenerator.EnemyList.RemoveAt(0);
        if (PlayerController.life > 0)
        {
            PlayerController.life -= damage;
        }
    }
}
