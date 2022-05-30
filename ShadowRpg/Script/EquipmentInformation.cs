using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentInformation : MonoBehaviour
{
    [SerializeField] Text equipmentInfoText;
    [SerializeField] Text equipmentNameText;
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
