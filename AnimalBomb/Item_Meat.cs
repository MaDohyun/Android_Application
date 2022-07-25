using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Meat : Item
{
    [SerializeField] GameObject equiptment_Meat;

    public void OnTriggerEnter(Collider other)
    {
        if (itemActive)
        {
            //アイテムは爆発に触れるとなくなる
            if (other.CompareTag("Explosion") && notDestroyActive)
            {
                Destroy(this.gameObject);
            }
            //プレイヤーに触れるとプレイヤーにmeatアイテムを設定する。
            if (other.CompareTag("Player"))
            {
                GameObject meat = Instantiate(equiptment_Meat,other.transform);
                meat.GetComponent<Equiptment_Meat>().SetMeat();
                //プレイヤーがアイテムを得るときの音を流す。
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
            //CPUに触れるとCPUにmeatアイテムを設定する。
            else if (other.CompareTag("CPU"))
            {
                GameObject meat = Instantiate(equiptment_Meat, other.transform);
                meat.GetComponent<Equiptment_Meat>().SetMeat();
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
        }
       
    }
}