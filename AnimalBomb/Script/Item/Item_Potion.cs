using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Potion : Item
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
            //プレイヤーに触れるとプレイヤーの速度が増える。
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().playerSpeed += 0.3f;
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
            //CPUに触れるとCPUの速度が増える。
            else if (other.CompareTag("CPU"))
            {
                other.GetComponent<CPU>().cpuSpeed += 0.3f;
                Destroy(gameObject);
            }
        }
    }
}

