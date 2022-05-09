using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string NAME;
    public float DAMAGE;
    public float HP;
    public float DEFFENCE;
    public float RANGE;
    public string SKILL;
    public string SKILLINFO;
    public bool right = true;

    GameObject hpbar;
    public GameObject closeenemy;
    private float closeenemydistance;


    enum directionState { left, right };
    directionState directionstate = directionState.right;

    Animator animator;

    public float atkCooltime = 4;
    public float atkDelay;
    public int characterspeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        closeenemydistance = 100000;
       
    }

    // Update is called once per frame
    void Update()
    {
        
            CalCloseEnemy();
      
        changedirection();
        if (atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }
        
        if (directionstate == directionState.left)
        {
            right = false;
        }
        else if (directionstate == directionState.right)
        {
            right = true;
        }
    }


    public void changedirection()
    {
        if (closeenemy != null)
        {
            if (directionstate == directionState.left)
            {
                if (transform.position.x < closeenemy.transform.position.x)
                {
                    // hpbar.transform.Rotate(0, 180, 0);
                    transform.Rotate(0, 180, 0);
                    directionstate = directionState.right;
                }
            }
            else if (directionstate == directionState.right)
            {
                if (transform.position.x > closeenemy.transform.position.x)
                {
                    //  hpbar.transform.Rotate(0, 180, 0);
                    transform.Rotate(0, 180, 0);
                    directionstate = directionState.left;
                }
            }
        }
    }
    public void CalCloseEnemy()
    {
        if (EnemyList.enemylist.Count > 0)
        {
            if (closeenemy == null)
            {
                closeenemydistance = 100000;
            }
            for (int i = 0; i < EnemyList.enemylist.Count; i++)
            {
                if (closeenemydistance > Vector2.Distance(transform.position,
                    EnemyList.enemylist[i].gameObject.transform.position))
                {
                    closeenemy = EnemyList.enemylist[i].gameObject;
                    closeenemydistance = Vector2.Distance(transform.position,
                    EnemyList.enemylist[i].gameObject.transform.position);
                }
            }
        }
    }
    public Transform boxpos;
    public Vector2 boxSize;

    public virtual void Attack()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(boxpos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Enemy")
            {
            collider.gameObject.GetComponent<Enemy>().TakeDamege(DAMAGE);
              
            }
        }

    }
   
    public void TakeDamege(float damage)
    {

        if (HP > 0)
        {
            HP -= damage;
        }

    }

    private void LateUpdate()
    {
       
    }


}
