using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//インベントリーの中の装備の情報を表すクラス
public class EquipmentInformation : MonoBehaviour
{
    //装備の情報text
    [SerializeField] Text equipmentInfoText;
    //装備の名前text
    [SerializeField] Text equipmentNameText;
    //情報を表す装備
    [HideInInspector] public Equipment equipment;
    // Update is called once per frame
    void Update()
    {
        if (equipment != null)
        {

            equipmentNameText.text = equipment.NAME;
            equipmentInfoText.text = "Skill:" + equipment.info + "\n" 
                                      ;
           
        }

    }
}
