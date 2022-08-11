using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMiniPlayer : MonoBehaviour
{
    //生成されたモンスター数
    public int createMonsterCounter;
    //残っているモンスター数
    public int lastMonsterCounter;
    private Vector2 vec2;
   
    void Update()
    {//残っているモンスター数を生成されたモンスター数に分けてミニマップのプレイヤーアイコンを前進させる。
        createMonsterCounter = EnemyGenerator.monstercounter;
        lastMonsterCounter = EnemyGenerator.EnemyList.Count;
        vec2.Set(3 + 3.9f -
            (3.9f * lastMonsterCounter / createMonsterCounter), 4.26f);
        transform.position = vec2;
    }
    
}
