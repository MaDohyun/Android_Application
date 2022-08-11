using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//キャラクターを編成するpanel
public class ShadowSelectionPanel : MonoBehaviour
{
    //プレイヤーhaveShadowListの中のキャラクター表すslot
    public ShadowSlot[] shadowSlots;
    public Transform slotHolder;
    //プレイヤーBattleShadowListの中のキャラクター表すslot
    public ShadowSelectedSlot[] shadowSelectedSlots;
    public Transform selectedslotHolder;
    // Start is called before the first frame update
    void Awake()
    {
        shadowSlots = slotHolder.GetComponentsInChildren<ShadowSlot>();
        shadowSelectedSlots = selectedslotHolder.GetComponentsInChildren<ShadowSelectedSlot>();

    }
    //shadowSlotsにプレイヤーhaveShadowListの中のキャラクターを描く
    public void SetShadowSlot()
    {
        for (int i = 0; i < shadowSlots.Length; i++)
        {
            shadowSlots[i].ResetSlot();
        }
        for (int i = 0; i < Player.instance.haveShadowList.Count; i++)
        {
            shadowSlots[i].SetShadow(Player.instance.haveShadowList[i]);
            shadowSlots[i].drawSlotSprite(Player.instance.haveShadowList[i].shadowImage);
            shadowSlots[i].SetselectedBorderLine();
        }
    }
    //shadowSelectedSlotsにプレイヤーBattleShadowListの中のキャラクターを描
    public void SetSelectedShadowSlot()
    {
        for (int i = 0; i < shadowSelectedSlots.Length; i++)
        {
            shadowSelectedSlots[i].SlotImageOff();
        }
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {if (shadowSelectedSlots.Length >= Player.instance.battleShadowList.Count)
            {
                shadowSelectedSlots[i].drawSlotSprite(Player.instance.battleShadowList[i].shadowImage);
            }
        }
    }
}
