using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : Enemy
{
    public int life;
    public int damage;
    Animator animator;
    //FlyingEyeの回避位置
    private Vector2 flyingvec3;
    //FlyingEyeの攻撃位置
    private Vector3 playerflyingvec3;
    private Vector2 runflyingvec3;
    private bool run;

    // Start is called before the first frame update
    void Start()
    {
        run = false;
        animator = GetComponent<Animator>();
        flyingvec3 = new Vector2(+0.7f,+0.0f);
        playerflyingvec3 = new Vector3(- 2.0f, -1.0f);
        runflyingvec3 = new Vector2(-1.0f, +1.0f) ;
    }

    // Update is called once per frame
    void Update()
    {
        if(run == true)
        {
            transform.Translate(runflyingvec3 * Time.deltaTime*10);
        }
    }
    public override void DamagedAction()
    {
        animator.SetTrigger("damaged");
        transform.position = flyingvec3;
        Invoke("counter",0.3f);
        //FlyingEyeはプレイヤーより速く行動するので攻撃される場合攻撃されず回避して反撃する。
        if (PlayerController.life > 0)
        {
            PlayerController.life -= damage;
        }
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
    //FlyingEyeはプレイヤーより速く行動するのでプレイヤーが防御しても攻撃する。
    public override void PlayerDefenceAction()
    {
        animator.SetTrigger("damaged");
        transform.position = flyingvec3;
        Invoke("counter", 0.3f);
        if (PlayerController.life > 0)
        {
            PlayerController.life -= damage;
        }
    }
    //FlyingEyeはプレイヤーが何の行動もしない時逃げる
    public override void AttackAction()
    {
        run = true;
        Destroy(this.gameObject, 0.5f);
        EnemyGenerator.EnemyList.RemoveAt(0);
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
    //反撃する時の行動
    public void counter()
    {
        transform.position = playerflyingvec3;
      
    }
}
