using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Oil : Item
{
    public void OnTriggerEnter(Collider other)
    {
        if (itemActive)
        {
            // アイテムは爆発に触れるとなくなる
            if (other.CompareTag("Explosion") && notDestroyActive)
            {
                Destroy(this.gameObject);
            }
            //プレイヤーに触れるとプレイヤーの爆弾威力が増える。
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().playerExplosionPower += 1;
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
            //CPUに触れるとCPUの爆弾威力が増える。
            else if (other.CompareTag("CPU"))
            {
                other.GetComponent<CPU>().cpuExplosionPower += 1;
                Destroy(gameObject);
            }
        }
    }
}
