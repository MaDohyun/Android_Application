using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //敵の名前
    public string NAME;
    //敵の攻撃力
    public float DAMAGE;
    //敵の生命力
    public float HP;
    //敵の防御力
    public float DEFFENCE;
    //敵の攻撃範囲
    public int RANGE;
    //敵の最大攻撃範囲
    protected int MAXRANGE = 3;
    //敵の最大生命力
    protected float MAXHP;
    protected Animator animator;
    //敵のアクションクールタイム
    public float actionCooltime;
    //敵のアクションクータイマー
    public float actionDelay;
    //敵のアクションクータイマースピード
    public float actionDealySpeed;
    //敵のアクションクがOn状態かどうか
    public bool actionOn;
    //敵がバトル中であるかどうか
    public bool isBattle;
    //敵の登場スピード
    public int appearSpeed = 3;
    //敵のバトル位置
    public Transform battlePosition;
    //敵のバトルナンバー
    public int battlePositionNumber;
    //バトル中のターゲット
    public Shadow targetShadow;
    protected virtual void Start()
    {
        MAXHP = HP;
        animator = GetComponent<Animator>();
        actionDealySpeed = 1;

    }
    protected virtual void Update()
    {
        // 敵はスキルなどで生命力が増えても最初の生命力を超えることができない
        if (HP > MAXHP)
        {
            HP = MAXHP;
        }
        //敵はスキルなどで攻撃範囲が増えても最大の攻撃範囲を超えることができない
        if (RANGE > MAXRANGE)
        {
            RANGE = MAXRANGE;
        }
        //敵ははバトル位置にいる場合アクションクータイマーが動く
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
        //アクションクータイマーが敵アクションクールタイムより大きい場合敵のアクションクがOn（true）になる。
        if (actionCooltime <= actionDelay)
        {
            actionOn = true;
        }
        //アクションクータイマーが敵アクションクールタイムより小さい場合敵のアクションクがOn（false）になる。
        else if (actionCooltime > actionDelay)
        {
            actionOn = false;
        }

    }
    //バトル位置を指定する。
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

    //ターゲットを攻撃する。
    public virtual void Attack()
    {

        targetShadow.TakeDamege(DAMAGE);

    }
    //ダメージを受ける。
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
        //生命力が０より小さい場合死ぬ
        if (HP <= 0)
        {
            animator.SetBool("Death", true);

        }
    }
    public GameObject damageStateText;
    public Transform TextAppearTransform;

    //受けるダメージを表すtext
    public void CreateDamageText(int damage)
    {
        GameObject Text = Instantiate(damageStateText);
        Text.transform.position = TextAppearTransform.position;
        Text.GetComponent<DamageStateText>().damage = damage;
    }
    //状態を表すtext
    public void CreateStateText(string state)
    {
        GameObject Text = Instantiate(damageStateText);
        Text.transform.position = TextAppearTransform.position;
        Text.GetComponent<DamageStateText>().state = state;
    }


}

 