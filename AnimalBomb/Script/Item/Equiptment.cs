using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの中に持って使うアイテムのクラス
public class Equiptment : MonoBehaviour
{
    //所有者のタイプ
    protected enum ParentType {player,cpu}
    protected ParentType parentType;
    protected Player player;
    protected CPU cpu;

    //所有者を設定する。
    protected void Set()
    {
        if (transform.parent.GetComponent<Player>())
        {
            parentType = ParentType.player;
            player = transform.parent.GetComponent<Player>();
        }
        else if (transform.parent.GetComponent<CPU>())
        {
            parentType = ParentType.cpu;
            cpu = transform.parent.GetComponent<CPU>();
        }
    }
   
}
