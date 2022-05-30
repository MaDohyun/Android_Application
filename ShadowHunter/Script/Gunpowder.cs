using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunpowder : Equipment
{
    public ParticleSystem Explosion;
    [SerializeField] float damage;
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

    public override void UseEquiptment()
    {
        Explosion.Play();
        Invoke("StopParticle", 3.0f);
        for(int i=0;i< BattleManager.battleEnemyList.Count; i++)
        {
            BattleManager.battleEnemyList[i].HP -= damage;
        }


    }
    public void StopParticle()
    {
        Explosion.Stop();
    }
}
