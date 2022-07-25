using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//itemの継承クラス
public class Item : MonoBehaviour
{
    //アイテムは作られた後連鎖爆発から破壊されることを防ぐためにブロックが破壊された後notDestroyTimerの時間ほど破壊されない時間を持つ
    [HideInInspector] public float  notDestroyTimer;
    public bool itemActive = false;
    [SerializeField]protected bool notDestroyActive = false;

    protected void Update()
    {
        if(notDestroyTimer > 0)
        {
            notDestroyTimer -= Time.deltaTime;
            if(notDestroyTimer <= 0)
            {
                notDestroyActive = true;
            }
        }
    }
}
