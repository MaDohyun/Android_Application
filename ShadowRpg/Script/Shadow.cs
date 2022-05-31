using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public string NAME;
    public float DAMAGE;
    public float HP;
    public float DEFFENCE;
    public int RANGE;
    public int LEVEL;
    public string SKILL;
    int MAXRANGE = 3;
    float MAXHP;
    public string info;

    public Sprite shadowIcon;
    public Sprite skillIcon;
    public Sprite shadowImage;

    [HideInInspector] public bool isSelected;

    public float actionCooltime;
    [HideInInspector] public float actionDelay;
    [HideInInspector] public float actionDealySpeed = 1;
    [HideInInspector] public bool actionOn;

    public float skillCooltime;
    [HideInInspector] public float skillDelay;
    [HideInInspector] public bool skillOn;

    public int appearSpeed = 3;

     public Transform battlePosition;
     public int battlePositionNumber;

    [HideInInspector] public enum ActionState { Attack, Defend,Death ,Ready ,Skill} ;
    [HideInInspector] public ActionState actionState;

    protected Animator animator;

    public Enemy targetEnemy;
    protected virtual void Start()
    {
        MAXHP = HP;
        animator = GetComponent<Animator>();
        skillDelay = skillCooltime;
    }
    protected virtual void Update()
    {
        if (HP > MAXHP)
        {
            HP = MAXHP;
        }
        if (RANGE > MAXRANGE)
        {
            RANGE = MAXRANGE;
        }

        if (DEFFENCE > 90)
        {
            DEFFENCE = 90;
        }

        if (Mathf.Abs(transform.position.x - battlePosition.position.x) < 0.1f && actionOn == false)
        {
            if (actionDelay < actionCooltime)
            {
                actionDelay += Time.deltaTime* actionDealySpeed;
            }
        }

        if (actionCooltime <= actionDelay)
        {
            actionOn = true;
        }
        else if (actionCooltime > actionDelay)
        {
            actionOn = false;
        }

        if (skillDelay > 0)
        {
            skillDelay -= Time.deltaTime * actionDealySpeed;
        }
        if (skillDelay <= 0)
        {
            skillOn = true;
        }
        else if (skillDelay > 0)
        {
            skillOn = false;
        }

        DefendOff();
    }
    public void SetBattlePosition(Transform battlePosition)
    {
        this.battlePosition = battlePosition;
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            if (Player.instance.battleShadowList[i].gameObject == this.gameObject)
            {
                battlePositionNumber = i + 1;
                return;
            }
        }
    }

  
    public virtual void Attack()
    {
        
       targetEnemy.TakeDamege(DAMAGE);
           
    }
    public virtual void TakeDamege(float damage)
    {
        if (actionState != ActionState.Defend)
        {
            if (HP > 0)
            {
                animator.SetTrigger("Hit");
                HP -= damage* (100-DEFFENCE)/100;
                CreateDamageText((int)(damage * (100 - DEFFENCE) / 100));
            }
        }
        if (actionState == ActionState.Defend)
        {
            if (HP > 0)
            {
              
                HP -= damage * 1 / 2* (100 - DEFFENCE) / 100;
                CreateDamageText((int)(damage * (100 - DEFFENCE) / 100* 1/2));
            }
        }

    }

    public virtual void AttackAnime()
    {
        if (isSelected && Player.instance.battleShadowList.Count > 0 &&BattleManager.battleEnemyList.Count>0&& actionOn)
        {
            actionDelay = 0;
            actionOn = false;
            animator.SetTrigger("Attack");
            actionState = ActionState.Attack;
            
        }
    }

    public void DefendAnime()
    {
        if (isSelected && actionOn)
        {
            actionDelay = 0;
            actionOn = false;
            animator.SetBool("Defend", true);
            actionState = ActionState.Defend;
        }
    }

    public virtual void SkillAnime()
    {
        if (Mathf.Abs(transform.position.x - battlePosition.position.x) < 0.1f)
        {
            if (isSelected && actionOn)
            {
                actionDelay = 0;
                actionOn = false;
                skillDelay = skillCooltime;
                skillOn = false;
                animator.SetBool("Skill", true);
                actionState = ActionState.Skill;
            }
        }

    }

    public void DefendOff()
    {
            if (actionOn && actionState == ActionState.Defend)
            {
                animator.SetBool("Defend", false);

            }
        
    }
    private void LateUpdate()
    {
       
        if (HP <= 0)
        {
            actionState = ActionState.Death;
            animator.SetBool("Death", true);

        }
    }
    public GameObject damageStateText;
    public Transform TextAppearTransform;

  public void CreateDamageText(int damage)
    {
        GameObject Text = Instantiate(damageStateText);
        Text.transform.position = TextAppearTransform.position;
        Text.GetComponent<DamageStateText>().damage = damage;
    }
    public void CreateStateText(string state)
    {
        GameObject Text = Instantiate(damageStateText);
        Text.transform.position = TextAppearTransform.position;
        Text.GetComponent<DamageStateText>().state = state;
    }

}
