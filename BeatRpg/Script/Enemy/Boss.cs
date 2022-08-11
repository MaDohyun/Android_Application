using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public int life;
    public int damage;
    //スキルの進行段階
    public int skillstate;
    public int skilldamage;
    Animator animator;
    private int random;
    private int skilltimer;
    //まだUnityの機能を詳しく知らなかったため、ゲームオブジェクトを大きくする方法が分からず、
    //サイズの異なるゲームオブジェクトをそれぞれ配置し、スキルがどんどん大きくなる効果を実装しました。
    public GameObject skilleffect1;
    public GameObject skilleffect2;
    public BossSkillEffect skilleffect3;
    public GameObject skilleffect4;
    private GameObject newskilleffect;
    private BossSkillEffect newbossskilleffect;
    //スキルゲームオブジェクトをOn、Offするためのbool変数
    private bool effect1;
    private bool effect2;
    private bool effect3;
    private bool effect4;
  
    void Start()
    {
        effect1 = false;
        effect2 = false;
        effect3 = false;
        effect4 = false;
        skillstate = 0;
        skilltimer = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {//スキルの進行段階が1の場合skillcastをOnしてBossCastのアニメにする。
        if (skillstate == 1)
        {
            animator.SetBool("skillcast", true);
        }
        random = Random.Range(1, 5);
        //スキルタイマーが1で、effect1が偽の場合skilleffect1を生成する
        //skilleffect1はスキルオブジェクトである。
        if (skilltimer == 1 && effect1 == false)
            {
                newskilleffect = Instantiate(skilleffect1);
                effect1 = true;
            }
        //スキルタイマーが2で、effect2が偽の場合skilleffect1を破壊してskilleffect2を生成する
       
        if (skilltimer == 2 && effect2 == false)
            {
                Destroy(newskilleffect.gameObject);
                newskilleffect = Instantiate(skilleffect2);
                effect2 = true;
            }
        //スキルタイマーが3で、effect3が偽の場合skilleffect2を破壊してskilleffect3を生成する

        if (skilltimer == 3 && effect3 == false)
            {
                Destroy(newskilleffect.gameObject);
                newbossskilleffect = Instantiate(skilleffect3);
                effect3 = true;
            }
        //スキルタイマーが4で、effect4が偽の場合skilleffect4を生成する
        //skilleffect4は最後のスキルオブジェクトである。

        if (skilltimer == 4 && effect4 == false)
            {
                newskilleffect = Instantiate(skilleffect4);
                effect4 = true;
            }
        
    }
    //攻撃される場合の行動
    public override void DamagedAction()
    {
        //skillstateが0の場合スキルをしていないため普通に攻撃される。
        if (skillstate == 0)
        {
            reducelife(PlayerController.damage);
            //攻撃された後HPが残っている場合反撃したりスキルを使い始める。

            if (EnemyGenerator.EnemyList[0].getLife() > 0)
            {
                animator.SetTrigger("damaged");
                if (random != 1)
                {
                    Invoke("AttackAction", 0.1f);
                }
                if (random == 1)
                {
                    Invoke("SkillAction", 0.1f);
                }
            }
        }
        //skillstateが1の場合スキルをしているため2倍のダメージで攻撃される。
        if (skillstate == 1)
        {
            reducelife(PlayerController.damage*2);
            if (EnemyGenerator.EnemyList[0].getLife() > 0)
            {
                skilltimer += 1;
                //攻撃された効果は赤に変わることで表す。
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Invoke("ReturnColor", 0.2f);
                
            }
            //skillstateが1でスキルタイマーが5の場合そのままスキルを発動させる。

            if (skilltimer == 5)
            {
                skillstate = 0;
                skilltimer = 0;
                effect1 = false;
                effect2 = false;
                effect3 = false;
                effect4 = false;
                newbossskilleffect.SkillAction();
                Destroy(newskilleffect);
                Destroy(newbossskilleffect.gameObject, 1.0f);
                if (PlayerController.life > 0)
                {
                    PlayerController.life -= skilldamage;
                }

            }
        }
        //HPが0以下の場合死ぬ。

        if (EnemyGenerator.EnemyList[0].getLife() <= 0)
        {
            DeathAction();
            EnemyGenerator.EnemyList.RemoveAt(0);
        }


        
    }
    //死ぬアニメ
    public override void DeathAction()
    {
        animator.SetTrigger("death");
        Destroy(this.gameObject, 2.5f);
    }
    //プレイヤーが防御行動を取った場合の行動
    public override void PlayerDefenceAction()
    {
        if (skillstate == 0)
        {
            //反撃したりスキルを使い始める。
            if (EnemyGenerator.EnemyList[0].getLife() > 0)
            {
                if (random != 1)
                {
                    animator.SetTrigger("attack");
                }
                if (random == 1)
                {
                    Invoke("SkillAction", 0.1f);
                }
            }
        }

        if (skillstate == 1)
        {
            if (skilltimer != 5)
            {
                skilltimer += 1;
            }

            //skillstateが1でスキルタイマーが5の場合そのままスキルを発動させる。
            if (skilltimer == 5)
            {
                skillstate = 0;
                skilltimer = 0;
                effect1 = false;
                effect2 = false;
                effect3 = false;
                effect4 = false;
                newbossskilleffect.SkillAction();
                Destroy(newskilleffect);
                Destroy(newbossskilleffect.gameObject, 1.0f);
               
            }
           
        }
    }
    //攻撃行動を取った場合の行動
    public override void AttackAction()
    {
        if (skillstate == 0)
        {
            animator.SetTrigger("attack");
            if (PlayerController.life > 0)
            {
                PlayerController.life -= damage;
            }
        }

        if (skillstate == 1)
        {
            if (skilltimer != 5)
            {
                skilltimer += 1;
            }

            if (skilltimer == 5)
            {
                skillstate = 0;
                skilltimer = 0;
                effect1 = false;
                effect2 = false;
                effect3 = false;
                effect4 = false;
                newbossskilleffect.SkillAction();
                Destroy(newskilleffect);
                Destroy(newbossskilleffect.gameObject, 1.0f);
                if (PlayerController.life > 0)
                {
                    PlayerController.life -= skilldamage;
                }
            }
            if (skilltimer > 5)
            {
                Debug.Log("bug");
            }
        }

    }
    //スキルをする場合の行動
    public override void SkillAction()
    {
        skillstate = 1;
        animator.SetTrigger("skill");
        skilltimer += 1;
    }
    //HPを減少させる。
    public override int reducelife(int x)
    {
        life = life - x;
        return life;
    }
    //HPを返す。
    public override int getLife()
    {
        return life;
    }
    //元の色に戻る。
    public void ReturnColor()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
   
}
