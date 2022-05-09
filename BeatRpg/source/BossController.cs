using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    public int life;
    public int damage;
    public int skillstate;
    public int skilldamage;
    Animator animator;
    private int random;
    private int skilltimer;
    public GameObject skilleffect1;
    public GameObject skilleffect2;
    public SkillController skilleffect3;
    public GameObject skilleffect4;
    private GameObject newskilleffect1;
    private GameObject newskilleffect2;
    private SkillController newskilleffect3;
    private bool effect1;
    private bool effect2;
    private bool effect3;
    private bool effect4;
  
    // Start is called before the first frame update
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
    {
        if (skillstate == 1)
        {
            animator.SetBool("skill3", true);
        }
        random = Random.Range(1, 5);
        if(skilltimer == 1 && effect1 == false)
        {
            newskilleffect1 = Instantiate(skilleffect1);
            effect1 = true;
        }
        if (skilltimer == 2 && effect2 == false)
        {
            Destroy(newskilleffect1.gameObject);
            newskilleffect1 = Instantiate(skilleffect2);
            effect2 = true;
        }
        if (skilltimer == 3 && effect3 == false)
        {
            Destroy(newskilleffect1.gameObject);
            newskilleffect3 = Instantiate(skilleffect3);
            effect3 = true;
        }
        if (skilltimer == 4 && effect4 == false)
        {
            newskilleffect2 = Instantiate(skilleffect4);
            effect4 = true;
        }
       

    }
    public void Action()
    {

    }
    public override void DamagedAction()
    {
        if (skillstate == 0)
        {
            reducelife(PlayerController.damage);
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
            Debug.Log(life);
        }
        if (skillstate == 1)
        {
            reducelife(PlayerController.damage*2);
            if (EnemyGenerator.EnemyList[0].getLife() > 0)
            {
                skilltimer += 1;
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Invoke("ReturnColor", 0.2f);
                
            }
            if (skilltimer == 5)
            {
                skillstate = 0;
                skilltimer = 0;
                effect1 = false;
                effect2 = false;
                effect3 = false;
                effect4 = false;
                newskilleffect3.SkillAction();
                Destroy(newskilleffect2);
                Destroy(newskilleffect3.gameObject, 1.0f);
                if (PlayerController.life > 0)
                {
                    PlayerController.life -= skilldamage;
                }

            }
            if (skilltimer > 5)
            {
                Debug.Log("bug");
            }
            Debug.Log(life);
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
        Destroy(this.gameObject, 2.5f);
    }
    public override void DefenceAction()
    {
        if (skillstate == 0)
        {
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

            if (skilltimer == 5)
            {
                skillstate = 0;
                skilltimer = 0;
                effect1 = false;
                effect2 = false;
                effect3 = false;
                effect4 = false;
                newskilleffect3.SkillAction();
                Destroy(newskilleffect2);
                Destroy(newskilleffect3.gameObject, 1.0f);
               
            }
            if (skilltimer > 5)
            {
                Debug.Log("bug");
            }
        }
    }
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
                newskilleffect3.SkillAction();
                Destroy(newskilleffect2);
                Destroy(newskilleffect3.gameObject, 1.0f);
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
    public override void SkillAction()
    {
       
        skillstate = 1;
        animator.SetTrigger("skill");
        skilltimer += 1;
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
    public void ReturnColor()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
   
}
