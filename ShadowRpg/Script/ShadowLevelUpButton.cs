using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLevelUpButton : MonoBehaviour
{
    //レベルアップさせるキャラクター
    [HideInInspector] public Shadow shadow;
    //ボタンを押すとキャラクターの能力値を変更させる。
    public void LevelUpShadow()
    {
       
        if (Player.instance.Money >= 100 && shadow != null)
        {
            shadow.LEVEL += 1;
            shadow.HP = shadow.HP * 1.2f;
            shadow.DAMAGE = shadow.DAMAGE * 1.3f;
            shadow.DEFFENCE += 10;
            Player.instance.Money -= 100;
        }
      
    }
}
