using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//AppleOrb装備のクラス
public class AppleOrb : Equipment
{
    //ParticleSystemのオブジェクト
    public GameObject heal;
    //healが続く時間のタイマー
    float healtimer = 0;
    //HPを足す量
    [SerializeField] float healVolume;
    private void Start()
    {
        timer = cooltime;
    }

    // Update is called once per frame
    void Update()
    {//healtimerタイマーが０より大きい場合PlayerクラスのbattleShadowList配列の中にあるキャラクターのHPにhealVolumeをたす。
        if (healtimer > 0)
        {
            healtimer -= Time.deltaTime;
            for(int i = 0; i< Player.instance.battleShadowList.Count; i++)
            {
                Player.instance.battleShadowList[i].HP += Time.deltaTime* healVolume;
            }
        }
        //Playerの状態がbattleである場合timerを作動させる。
        if (Player.instance.playerState == Player.PlayerState.battle)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
        //Playerの状態がbattleでない場合timerをリセットする。
        else if (Player.instance.playerState != Player.PlayerState.battle)
        {
            timer = cooltime;
        }
        //タイマーが0より小さくなる場合装備を使う。
        if (timer <= 0)
        {
            UseEquiptment();
            timer = cooltime;
        }
    }
    //heal ParticleSystemのオブジェクトを作ってhealtimerをセットする。
    public override void UseEquiptment()
    {
        Instantiate(heal);
        healtimer = 5.0f;
    }
    
}
