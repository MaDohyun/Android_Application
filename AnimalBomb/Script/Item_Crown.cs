using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Crown : Item
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
            //プレイヤーに触れるとプレイヤーの爆弾威力や爆弾数がMax値になる。
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().playerExplosionPower = other.GetComponent<Player>().playerMaxExplosionPower;
                other.GetComponent<Player>().playerExplosionAmount = other.GetComponent<Player>().playerMaxExplosionAmount;
                other.GetComponent<Player>().playerSpeed = other.GetComponent<Player>().playerMaxSpeed;
                //プレイヤーがアイテムを得るときの音を流す。
                SoundManager.instance.PlayGetCrownSound();
                Destroy(gameObject);
            }
            //CPUに触れるとCPUの爆弾威力や爆弾数がMax値になる。
            else if (other.CompareTag("CPU"))
            {
                other.GetComponent<CPU>().cpuExplosionPower = other.GetComponent<CPU>().cpuMaxExplosionPower;
                other.GetComponent<CPU>().cpuExplosionAmount = other.GetComponent<CPU>().cpuMaxExplosionAmount;
                other.GetComponent<CPU>().cpuSpeed = other.GetComponent<CPU>().cpuMaxSpeed;

                Destroy(gameObject);
            }
        }
    }
}
