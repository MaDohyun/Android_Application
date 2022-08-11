using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//敵のHpを用いたゲージバー
public class EnemyHpBarController : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    [SerializeField]
    private Enemy enemy;

    private float maxhp;
    private float curhp;
    private float resulthp;


    // Start is called before the first frame update
    void Start()
    {
       
        maxhp = enemy.HP;
        curhp = enemy.HP;
        hpbar.value = (float)curhp / (float)maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        curhp = enemy.HP;
       
        HandleHP();

    }
    private void HandleHP()
    {//線形補間を用いて柔らかなゲージバーを実装
        hpbar.value = Mathf.Lerp(hpbar.value, (float)curhp / (float)maxhp, Time.deltaTime * 10);
    }
}

