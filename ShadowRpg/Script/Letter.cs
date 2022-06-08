using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : Equipment
{

    [SerializeField] ParticleSystem heart;

    int targetNumber;
    private void Start()
    {
        timer = cooltime;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.playerState == Player.PlayerState.battle)
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if (Player.instance.playerState != Player.PlayerState.battle)
            {
                timer = cooltime;
            }
        if (timer <= 0)
        {
            UseEquiptment();
            timer = cooltime;
        }
    }
    //Letterは一番後ろの敵を一番前に動かす。
    public override void UseEquiptment()
    {
        targetNumber = BattleManager.battleEnemyList.Count - 1;
        transform.position = BattleManager.battleEnemyList[targetNumber].gameObject.transform.position;
        heart.Play();
        Invoke("StopParticle", 3.0f);
        //Insetを用いて一番前にする。
        BattleManager.battleEnemyList.Insert(0,BattleManager.battleEnemyList[targetNumber]);
        BattleManager.battleEnemyList.RemoveAt(targetNumber+1);
        
    }
    public void StopParticle()
    {
        heart.Stop();
    }

   
}
