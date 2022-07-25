using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自動で近いてきに向かって移動するボームアイテムクラス。
public class Equiptment_AutoBomb : Equiptment
{
    [Header("Prefab")]
    [SerializeField] GameObject autoBombPrefab;

    [SerializeField] int autoBombExplosionTime = 6;
    //アイテムを使う。
    public void UseItem()
    {
        //所有者がプレイヤーの場合
        if (parentType == ParentType.player)
        {
            if (autoBombPrefab)
            {
                //autoボームを作る。
                var pos = new Vector3
                    (Mathf.RoundToInt(transform.position.x), autoBombPrefab.transform.position.y, Mathf.RoundToInt(transform.position.z));
                GameObject bomb = Instantiate(autoBombPrefab, pos, autoBombPrefab.transform.rotation);
                //ボームを設定する。
                bomb.GetComponent<Bomb>().explosionPower = player.playerExplosionPower;
                bomb.GetComponent<Bomb>().maker = player.gameObject;
                bomb.GetComponent<Bomb>().explosionTime = autoBombExplosionTime;
                player.setBomsList.Add(bomb);
                //ボームを設置するときの音を流す。
                SoundManager.instance.PlaySetBombSound();
                Destroy(this.gameObject);
            }
        }
        //所有者がCPUの場合
        else if (parentType == ParentType.cpu)
        {
            if (autoBombPrefab)
            {
                var pos = new Vector3(Mathf.RoundToInt(transform.position.x), autoBombPrefab.transform.position.y,
                    Mathf.RoundToInt(transform.position.z));
                GameObject bomb = Instantiate(autoBombPrefab, pos, autoBombPrefab.transform.rotation);
                bomb.GetComponent<Bomb>().explosionPower = cpu.cpuExplosionPower;
                bomb.GetComponent<Bomb>().maker = cpu.gameObject;
                bomb.GetComponent<Bomb>().explosionTime = autoBombExplosionTime;
                cpu.setBomsList.Add(bomb);
                cpu.canAction = true;
                Destroy(this.gameObject);
            }
        }
    }
    //アイテムを初期設定する。
    public void SetAutoBomb()
    {
        Set();
        GameObject child;
        //所有者がすでにアイテムを持っている場合はもともと持っていたアイテムを破壊する。
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            if (transform.parent.transform.GetChild(i).GetComponent<Equiptment_AutoBomb>())
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
            player.autoBomb = this;
        }
        else if (parentType == ParentType.cpu)
        {
            cpu.autoBomb = this;
        }
    }
}
