using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_AutoBomb : Item
{
    [SerializeField] GameObject equiptment_AutoBOmb ;

    public void OnTriggerEnter(Collider other)
    {
        if (itemActive)
        {
            //アイテムは爆発に触れるとなくなる
            if (other.CompareTag("Explosion") && notDestroyActive)
            {
                Destroy(this.gameObject);
            }
            //プレイヤーに触れるとプレイヤーにAutoBombアイテムを設定する。
            if (other.CompareTag("Player"))
            {
                GameObject autoBomb = Instantiate(equiptment_AutoBOmb, other.transform);
                //Autoボームを設定させる。
                autoBomb.GetComponent<Equiptment_AutoBomb>().SetAutoBomb();
                //プレイヤーがアイテムを得るときの音を流す。
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
            //CPUに触れるとCPUにAutoBombアイテムを設定する。
            else if (other.CompareTag("CPU"))
            {
                GameObject autoBomb = Instantiate(equiptment_AutoBOmb, other.transform);
                autoBomb.GetComponent<Equiptment_AutoBomb>().SetAutoBomb();
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
        }

    }
}
