using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Scroll : Item
{
    [SerializeField] GameObject equiptment_Scroll;

    public void OnTriggerEnter(Collider other)
    {
        if (itemActive)
        {
            // アイテムは爆発に触れるとなくなる
            if (other.CompareTag("Explosion") && notDestroyActive)
            {
                Destroy(this.gameObject);
            }
            //プレイヤーに触れるとプレイヤーにscrollアイテムを設定する。
            if (other.CompareTag("Player"))
            {
                GameObject scroll = Instantiate(equiptment_Scroll, other.transform);
                scroll.GetComponent<Equiptment_Scroll>().SetScroll();
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
            //CPUに触れるとCPUにscrollアイテムを設定する。
            else if (other.CompareTag("CPU"))
            {
                GameObject scroll = Instantiate(equiptment_Scroll, other.transform);
                scroll.GetComponent<Equiptment_Scroll>().SetScroll();
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
        }

    }
}
