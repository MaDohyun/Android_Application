using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Crystal : Item
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
            //プレイヤーに触れるとアイテムがある破壊できるブロックが透明になる。
            if (other.CompareTag("Player"))
            {
                //ブロックの情報はHolderから取得する。
                for (int i=0;i< GameManager.instance.destructablewallHolder.childCount; i++)
                {
                    Color c = GameManager.instance.destructablewallHolder.GetChild(i).GetComponent<MeshRenderer>().materials[0].color;
                    c.a = 0.5f;
                    GameManager.instance.destructablewallHolder.GetChild(i).GetComponent<MeshRenderer>().materials[0].color = c;
                    
                }
                //プレイヤーがアイテムを得るときの音を流す。
                SoundManager.instance.PlayGetItemSound();
                Destroy(gameObject);
            }
            //CPUに触れるとそのまま自分を破壊する。
            else if (other.CompareTag("CPU"))
            {
                Destroy(gameObject);
            }
        }
    }
}
