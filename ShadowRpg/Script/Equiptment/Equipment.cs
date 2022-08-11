using System.Collections;
using System.Collections.Generic;
using UnityEngine;
　//装備クラス
public class Equipment : MonoBehaviour, IUseEquiptment
{
    //装備のクールタイム
    public float cooltime;
    //装備のタイマー
    public float timer;
    //装備のタイプ
    public enum EquiptType { active, passive }
    public EquiptType equiptType;
    //装備のアイコン
    public Sprite equiptmentIcon;
    //装備の名前
    public string NAME;
    //装備の情報
    public string info;
    //装備の効果
    public virtual void UseEquiptment()
    {

    }
}