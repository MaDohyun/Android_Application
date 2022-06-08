using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//装備があるインベントリーpanel
public class EquipmentPanel : MonoBehaviour
{
    //プレイヤーhaveEquipmentListの中の装備を表すslot
    public EquipmentSlot[] equipmentSlots;
    public Transform equipmentSlotHolder;

    //プレイヤーBattleEquipmentListの中の装備を表すslot
    public EquipmentSelectedSlot[] equipmentSelectedSlots;
    public Transform equipmentSelectedSlotHolder;

    void Awake()
    {
        equipmentSlots = equipmentSlotHolder.GetComponentsInChildren<EquipmentSlot>();
        equipmentSelectedSlots = equipmentSelectedSlotHolder.GetComponentsInChildren<EquipmentSelectedSlot>();
    }

    //equipmentSlotsにプレイヤーhaveEquipmentListの中の装備を描く
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
    //equipmentSelectedSlotsにプレイヤーBattleEquipmentListの中の装備を描く
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
