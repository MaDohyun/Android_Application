using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    public EquipmentSlot[] equipmentSlots;
    public Transform equipmentSlotHolder;


    public EquipmentSelectedSlot[] equipmentSelectedSlots;
    public Transform equipmentSelectedSlotHolder;
    // Start is called before the first frame update
    void Awake()
    {
        equipmentSlots = equipmentSlotHolder.GetComponentsInChildren<EquipmentSlot>();
        equipmentSelectedSlots = equipmentSelectedSlotHolder.GetComponentsInChildren<EquipmentSelectedSlot>();
    }

    // Update is called once per frame
    void Update()
    {
       
            
    }

    public void SetEquiptmentSlot()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].SlotImageOff();
        }
        for (int i = 0; i < Player.instance.haveEquipmentList.Count; i++)
        {
            equipmentSlots[i].SetEquiptment(Player.instance.haveEquipmentList[i]);
            equipmentSlots[i].drawSlotSprite(Player.instance.haveEquipmentList[i].equiptmentIcon);
        }
    }
    public void SetSelectedEquiptmentSlot()
    {
        for (int i = 0; i < equipmentSelectedSlots.Length; i++)
        {
            equipmentSelectedSlots[i].SlotImageOff();
        }
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {
            equipmentSelectedSlots[i].drawSlotSprite(Player.instance.battleEquipmentList[i].equiptmentIcon);
        }
    }
}
