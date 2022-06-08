using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShadowInformation : MonoBehaviour
{
    //キャラクターの情報text
    [SerializeField] Text shadowInfoText;
    //キャラクターの名前text
    [SerializeField] Text shadowNameText;
   [HideInInspector]  public Shadow shadow;
    // Update is called once per frame
    void Update()
    {
        if (shadow != null)
        {if (shadow.DEFFENCE < 90)
            {
                shadowNameText.text = shadow.name;
                shadowInfoText.text = "Level:" + shadow.LEVEL + "\n" +
                                      "HP:" + (int)shadow.HP + "\n" +
                                      "Damage:" + (int)shadow.DAMAGE + "\n" +
                                      "Deffence:" + (int)shadow.DEFFENCE + "%" + "\n" +
                                      "CoolTime:" + (int)shadow.actionCooltime + "\n" +
                                      "Range:" + shadow.RANGE + "\n" +
                                      "Skill:" + shadow.SKILL + "\n" +
                                      "";
            }
            else if (shadow.DEFFENCE >= 90)
            {
                shadowNameText.text = shadow.NAME;
                shadowInfoText.text = "Level:" + shadow.LEVEL + "\n" +
                                      "HP:" + (int)shadow.HP + "\n" +
                                      "Damage:" + (int)shadow.DAMAGE + "\n" +
                                      "Deffence:" + "90%" + "\n" +
                                      "CoolTime:" + (int)shadow.actionCooltime + "\n" +
                                      "Range:" + shadow.RANGE + "\n" +
                                      "Skill:" + shadow.SKILL + "\n" +
                                      "";
            }
        }

    }
}
