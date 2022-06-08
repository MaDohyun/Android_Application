using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    //キャラクターの名前
    public string NAME;
    //キャラクターの攻撃力
    public float DAMAGE;
    //キャラクターの生命力
    public float HP;
    //キャラクターの防御力
    public float DEFFENCE;
    //キャラクターの攻撃範囲
    public int RANGE;
    //キャラクターのレベル
    public int LEVEL;
    //キャラクターのスキル名
    public string SKILL;
    //攻撃の最大範囲
    int MAXRANGE = 3;
    //生命力の最大
    float MAXHP;
    //キャラクターの説明
    public string info;
    //キャラクターのアイコン
    public Sprite shadowIcon;
    //キャラクターのスキルアイコン
    public Sprite skillIcon;
    //キャラクターのイメージ
    public Sprite shadowImage;
    //バトル中に選ばれたかどうか
    [HideInInspector] public bool isSelected;
    //キャラクターアクションクールタイム
    public float actionCooltime;
    //キャラクターアクションクータイマー
    [HideInInspector] public float actionDelay;
    //キャラクターアクションクータイマースピード
    [HideInInspector] public float actionDealySpeed = 1;
    //キャラクターのアクションクがOn状態かどうか
    [HideInInspector] public bool actionOn;
    //キャラクタースキルクールタイム
    public float skillCooltime;
    //キャラクタースキルータイマー
    [HideInInspector] public float skillDelay;
    //キャラクターのスキルがOn状態かどうか
    [HideInInspector] public bool skillOn;
    //キャラクターの登場スピード
    public int appearSpeed = 3;
    //キャラクターのバトル位置
    public Transform battlePosition;
    //キャラクターのバトルナンバー
    public int battlePositionNumber;
    //キャラクターの状態
    [HideInInspector] public enum ActionState { Attack, Defend,Death ,Ready ,Skill} ;
    [HideInInspector] public ActionState actionState;

    protected Animator animator;
    //バトル中のターゲット
    public Enemy targetEnemy;
    protected virtual void Start()
    {
        MAXHP = HP;
        animator = GetComponent<Animator>();
        skillDelay = skillCooltime;
    }
    protected virtual void Update()
    {//キャラクターはスキルなどで生命力が増えても最初の生命力を超えることができない
        if (HP > MAXHP)
        {
            HP = MAXHP;
        }
        //キャラクターはスキルなどで攻撃範囲が増えても最大の攻撃範囲を超えることができない
        if (RANGE > MAXRANGE)
        {
            RANGE = MAXRANGE;
        }
        //キャラクターはスキルなどで防御力が増えても90%を超えることができない
        if (DEFFENCE > 90)
        {
            DEFFENCE = 90;
        }
        //キャラクターはバトル位置にいる場合アクションクータイマーが動く
        if (Mathf.Abs(transform.position.x - battlePosition.position.x) < 0.1f && actionOn == false)
        {
            if (actionDelay < actionCooltime)
            {
                actionDelay += Time.deltaTime* actionDealySpeed;
            }
        }
        //アクションクータイマーがキャラクターアクションクールタイムより大きい場合キャラクターのアクションクがOn（true）になる。
        if (actionCooltime <= actionDelay)
        {
            actionOn = true;
        }
        //アクションクータイマーがキャラクターアクションクールタイムより小さい場合キャラクターのアクションクがOn（false）になる。
        else if (actionCooltime > actionDelay)
        {
            actionOn = false;
        }
        //スキルタイマーの作動
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
        //キャラクターの状態がDefenceで、キャラクターのアクションクがOnの場合Idleアニメを通じてReady状態になる。
        DefendOff();
    }
    //キャラクターバトル位置を指定する。
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
    //ターゲットを攻撃する。
    public virtual void Attack()
    {
        
       targetEnemy.TakeDamege(DAMAGE);
           
    }
    //ダメージを受ける。
    public virtual void TakeDamege(float damage)
    {
        if (actionState != ActionState.Defend)
        {
            if (HP > 0)
            {
                animator.SetTrigger("Hit");
                //受けるダメージは防御力によって変わる
                HP -= damage* (100-DEFFENCE)/100;
                CreateDamageText((int)(damage * (100 - DEFFENCE) / 100));
            }
        }
        //キャラクターの状態がDefenceの場合受けるダメージは半分になる。
        if (actionState == ActionState.Defend)
        {
            if (HP > 0)
            {
              
                HP -= damage * 1 / 2* (100 - DEFFENCE) / 100;
                CreateDamageText((int)(damage * (100 - DEFFENCE) / 100* 1/2));
            }
        }

    }
    //キャラクターのAttackアニメを実行する。
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
    //キャラクターのDefendアニメを実行する。
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
    //キャラクターのスキルアニメを実行する。
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
    //animator.SetBool("Defend", false)通じてIdleアニメに戻る。
    public void DefendOff()
    {
            if (actionOn && actionState == ActionState.Defend)
            {
                animator.SetBool("Defend", false);

            }
        
    }
    private void LateUpdate()
    {//生命力が０より小さい場合死ぬ
        if (HP <= 0)
        {
            actionState = ActionState.Death;
            animator.SetBool("Death", true);
        }
    }
    public GameObject damageStateText;
    public Transform TextAppearTransform;

    //キャラクターが受けるダメージを表すtext
    public void CreateDamageText(int damage)
    {
        GameObject Text = Instantiate(damageStateText);
        Text.transform.position = TextAppearTransform.position;
        Text.GetComponent<DamageStateText>().damage = damage;
    }
    //キャラクターの状態を表すtext
    public void CreateStateText(string state)
    {
        GameObject Text = Instantiate(damageStateText);
        Text.transform.position = TextAppearTransform.position;
        Text.GetComponent<DamageStateText>().state = state;
    }

}
