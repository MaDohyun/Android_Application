using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    private List<GameObject> LifeList = new List<GameObject>();
    public int firstlife;
    public int firstdamage;
    static public int key = 0;
    static public int life;
    static public int damage;
    public GameObject Life;
    private Vector2 lifevector2;
    private Vector2 bossattackvec3;
    private Vector3 playerreturnkvec3;
    private int death;
    public AudioSource AttackSoundSource;
    public AudioSource DefenceSoundSource;
    public AudioClip AttackSoundClip;
    public AudioClip DefenceSoundClip;
    // Start is called before the first frame update
    void Start()
    {
        death = 0;
        bossattackvec3 = new Vector2(+2.0f, -1.0f);
        life = firstlife;
        damage = firstdamage;
        animator = GetComponent<Animator>();
        playerreturnkvec3 = transform.position;
        for (int i = 0; i < life; i++)
        { lifevector2 = new Vector2(-7.21f + i*0.85f,4.25f);
            GameObject newlife = Instantiate(Life,lifevector2, Quaternion.identity);
            LifeList.Add(newlife);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0 && death ==0)
        {
            death = 1;
        }
            if (death == 1)
        {
            animator.SetBool("death",true);
            death = 2;
            Invoke("Deathtrigger",1.5f);
            Invoke("GameOver", 2.5f);
        }
        if (LifeList.Count > life)
        {
            if (life > 0)
            {
                Invoke("Damaged", 0.15f);
                int minus = LifeList.Count - life;
                for (int i = 0; i < minus; i++)
                {
                    Destroy(LifeList[LifeList.Count - 1], 0);
                    LifeList.RemoveAt(LifeList.Count - 1);
                }
            }
            if (life == 0)
            {
                int minus = LifeList.Count - life;
                for (int i = 0; i < minus; i++)
                {
                    Destroy(LifeList[LifeList.Count - 1], 0);
                    LifeList.RemoveAt(LifeList.Count - 1);
                }
            }
            if (life < 0 && LifeList.Count >0)
            {
                for (int i = 1; i < LifeList.Count+1; i++)
                {
                    Destroy(LifeList[i-1]);
                    LifeList.RemoveAt(i-1);
                }
            }

        }
        if(life>0 && EnemyGenerator.EnemyList.Count == 0)
        {
            Invoke("GameClear", 2.5f);
        }
        key = RoundController.state;
        if (key == 1)
        {
            AttackSound();
            if (EnemyGenerator.EnemyList[0] is BossController)
            {
                transform.position = bossattackvec3;
                Invoke("PlayerReturn", 0.5f);
            }
            animator.SetTrigger("attack");
            RoundController.state = 0;
           
        }
        if (key == 2)
        {
            DefenceSound();
            animator.SetTrigger("defence");
            RoundController.state = 0;
        }
        if (key == 0)
        {
            
        }
       
    }
    public void Damaged()
    { 
        animator.SetTrigger("damaged");
    }
    public void PlayerReturn()
    {
       transform.position = playerreturnkvec3;
    }
    private void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    private void GameClear()
    {
        SceneManager.LoadScene(3);
    }
    private void Deathtrigger()
    {
        animator.SetBool("death", false);
    }
    private void AttackSound()
    {
        AttackSoundSource.PlayOneShot(AttackSoundClip);
    }
    private void DefenceSound()
    {
        DefenceSoundSource.PlayOneShot(DefenceSoundClip);
    }

}
