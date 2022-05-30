using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public string NAME;
    public float DAMAGE;
    public float HP;
    public float DEFFENCE;
    public int RANGE;
    protected int MAXRANGE = 3;
    protected float MAXHP;
    protected Animator animator;

    public float actionCooltime;
    public float actionDelay;
    public float actionDealySpeed;
    public bool actionOn;

    public bool isBattle;
    public int appearSpeed = 3;

    public Transform battlePosition;
    public int battlePositionNumber;

    public Shadow targetShadow;
    protected virtual void Start()
    {
        MAXHP = HP;
        animator = GetComponent<Animator>();
        actionDealySpeed = 1;

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
        if (isBattle)
        {
            if (Mathf.Abs(transform.position.x-battlePosition.position.x) < 0.1f && actionOn == false)
            {
                    if (actionDelay < actionCooltime)
                    {
                        actionDelay += Time.deltaTime* actionDealySpeed;
                    }
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

    }
    public void SetBattlePosition(Transform battlePosition)
    {
        this.battlePosition = battlePosition;
        for (int i = 0; i < BattleManager.battleEnemyList.Count; i++)
        {
            if (BattleManager.battleEnemyList[i].gameObject == this.gameObject)
            {
                battlePositionNumber = i+1;
                return;
            }
        }
    }

   
    public virtual void Attack()
    {

        targetShadow.TakeDamege(DAMAGE);

    }
    public virtual void TakeDamege(float damage)
    {
        if (HP > 0)
        {
            animator.SetTrigger("Hit");
            HP -= damage* (100 - DEFFENCE) / 100;
            CreateDamageText((int)(damage * (100 - DEFFENCE) / 100));
        }

    }

    private void LateUpdate()
    {
        if(battlePosition != null)
        {
            isBattle = true;
        }
        if (HP <= 0)
        {
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

 