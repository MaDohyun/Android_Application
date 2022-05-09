using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public string NAME;
    public float DAMAGE;
    public float HP;
    public float DEFFENCE;
    public float RANGE;

    public GameObject hpbar;
    public GameObject closecharacter;
    private float closecharacterdistance;

   
    public enum directionState { left, right };
    public directionState directionstate = directionState.left;

    Animator animator;
    
    public float atkCooltime = 4;
    public float atkDelay;
    public int enemyspeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        closecharacterdistance = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        
        CalCloseParty();
        changedirection();
        
        if (atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }
       
        
        
    }


    public virtual void changedirection()
    {
        if (closecharacter != null)
        {
            if (directionstate == directionState.left)
            {
                if (transform.position.x < closecharacter.transform.position.x)
                {
                    hpbar.transform.Rotate(0, 180, 0);
                    transform.Rotate(0, 180, 0);
                    directionstate = directionState.right;
                }
            }
            else if (directionstate == directionState.right)
            {
                if (transform.position.x > closecharacter.transform.position.x)
                {
                    hpbar.transform.Rotate(0, 180, 0);
                    transform.Rotate(0, 180, 0);
                    directionstate = directionState.left;
                }
            }
        }
    }

    public void CalCloseParty()
    { 
        if (PartyMember.Party.Count > 0)
        {
            if (closecharacter == null)
            {
                closecharacterdistance = 100000;
            }
            for (int i = 0; i < PartyMember.Party.Count; i++)
            {

                if (closecharacterdistance > Vector2.Distance(transform.position,
                    PartyMember.Party[i].transform.position))
                {
                    closecharacter = PartyMember.Party[i];
                    closecharacterdistance = Vector2.Distance(transform.position,
                    PartyMember.Party[i].transform.position);
                }
            }
        }
    }

    public Transform boxpos;
    public Vector2 boxSize;

    public void Attack()
    {
       
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(boxpos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Character")
                {
               collider.gameObject.GetComponent<Character>().TakeDamege(DAMAGE);
               
                }
            }
        
    }
    public void TakeDamege(float damage)
    {
        animator.SetTrigger("Hit");
        if (HP > 0)
        {
            HP -= damage;
        }
      
    }
    
    private void LateUpdate()
    {
        if (HP <= 0)
        {
            animator.SetBool("Death", true);

        }
    }




}
