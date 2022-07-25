using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equiptment_Meat : Equiptment
{
    public void UseItem()
    {
        //今向かっている方向の前にボームがある場合、その方向にボームを移動させる。
        RaycastHit bombhit;
        if (parentType == ParentType.player) {
            Physics.Raycast(player.transform.position + player.currentDirection * 0.5f, player.currentDirection, out bombhit, 0.1f, player.bombLayer);
            if (bombhit.collider)
            {
                bombhit.collider.GetComponent<Bomb>().Move(player.currentDirection);
            }
        }
        if (parentType == ParentType.cpu)
        {
            Physics.Raycast(cpu.transform.position + cpu.currentDirection * 0.5f, cpu.currentDirection, out bombhit, 0.1f, cpu.bombLayer);
            if (bombhit.collider)
            {
                bombhit.collider.GetComponent<Bomb>().Move(cpu.currentDirection);
            }
        }
    }
    //アイテムを初期設定する。
    public void SetMeat()
    {
        Set();
        GameObject child;
        //所有者がすでにアイテムを持っている場合はもともと持っていたアイテムを破壊する。
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            if (transform.parent.transform.GetChild(i).GetComponent<Equiptment_Meat>())
            {
                child = transform.parent.transform.GetChild(i).gameObject;
                if (child == this.gameObject)
                {
                }
                else
                {
                    Destroy(child);
                }
            }
        }
        //所有者の変数に自分を設定する。
        if (parentType == ParentType.player)
            {
                player.meat = this;
            }
        else if (parentType == ParentType.cpu)
        {
            cpu.meat = this;
        }
    }
}
