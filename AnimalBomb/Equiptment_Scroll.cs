using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equiptment_Scroll : Equiptment
{
    //見えなくなる時間
    float invisibleTimer;

    [Header("Trigger")]
    bool scrollActive = false;
    //プレイヤが見えなくなるときその時間の間はこのオブジェクトに変わる。
    [SerializeField] GameObject invisibleObject;
    //作った透明のプレイヤーオブジェクト
    GameObject invisible;
    private void Update()
    {
        if (invisibleTimer > 0)
        {
            invisibleTimer -= Time.deltaTime;
            //時間がすぎるとプレイヤーまたは、CPUは元の状態に戻る。
            if (invisibleTimer <= 0)
            {
                if (parentType == ParentType.player)
                {
                    player.tag = "Player";
                    Destroy(invisible);
                    player.playerModelObject.SetActive(true);
                    player.scroll = null;
                    //時間が終わると破壊される。
                    Destroy(this.gameObject);
                }
                else if (parentType == ParentType.cpu)
                {
                    cpu.tag = "CPU";
                    cpu.cpuModelObject.SetActive(true);
                    cpu.scroll = null;
                    Destroy(this.gameObject);
                }
            
            }
        }
    }
    public void UseItem()
    {
        if (!scrollActive)
        {
            scrollActive = true;
            if (parentType == ParentType.player)
            {
                //プレイヤーのtagが変わりオブジェクトモデルも変わる。
                //cpuはプレイヤーを認識できなくなる。c
                player.playerModelObject.SetActive(false);
                invisible = Instantiate(invisibleObject, player.transform);
                player.tag = "Invisible";
                invisibleTimer = 5.0f;
            }
            else if (parentType == ParentType.cpu)
            {
                //cpuのtagが変わり見えなくなる。
                cpu.cpuModelObject.SetActive(false);
                cpu.tag = "Invisible";
                invisibleTimer = 5.0f;
            }
        }
    }
    //アイテムを初期設定する。
    public void SetScroll()
    {
        Set();
        GameObject child;
        //所有者がすでにアイテムを持っている場合はもともと持っていたアイテムを破壊する。
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            if (transform.parent.transform.GetChild(i).GetComponent<Equiptment_Scroll>())
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
            player.scroll = this;
        }
        else if (parentType == ParentType.cpu)
        {
            cpu.scroll = this;
        }
        //このアイテムは入手した後すぐ使われる。
        UseItem();
    }
}
