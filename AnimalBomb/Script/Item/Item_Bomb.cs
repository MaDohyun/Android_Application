using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bomb : Item
{
    public void OnTriggerEnter(Collider other)
    {
        if (itemActive)
        {
            //アイテムは爆発に触れるとなくなる
            if (other.CompareTag("Explosion") && notDestroyActive)
            {
                Destroy(this.gameObject);
            }
            //プレイヤーに触れるとプレイヤーの設置できるボームの数が増える。
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().playerExplosionAmount += 1;
                //プレイヤーがアイテムを得るときの音を流す。
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
            //CPUに触れるとCPUの設置できるボームの数が増える。
            else if (other.CompareTag("CPU"))
            {
                other.GetComponent<CPU>().cpuExplosionAmount += 1;
                Destroy(gameObject);
            }
        }
    }
   
}
