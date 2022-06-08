using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//敵のアクションのタイマーはクールタイムを用いたゲージバー
public class EnemyActionGagueBarController : MonoBehaviour
{
    [SerializeField]
    private Slider ActionGaguebar;
    [SerializeField]
    private Enemy enemy;

    private float maxActionGague;
    private float curActionGague;
    private float resulActionGague;


    // Start is called before the first frame update
    void Start()
    {
        
        maxActionGague = enemy.actionCooltime;
        curActionGague = enemy.actionDelay;
        ActionGaguebar.value = (float)curActionGague / (float)maxActionGague;
    }

    // Update is called once per frame
    void Update()
    {
        curActionGague = enemy.actionDelay;

        HandleHP();

    }
    private void HandleHP()
    { //線形補間を用いて柔らかなゲージバーを実装
        ActionGaguebar.value = Mathf.Lerp(ActionGaguebar.value, (float)curActionGague / (float)maxActionGague, Time.deltaTime * 10);
    }
}

