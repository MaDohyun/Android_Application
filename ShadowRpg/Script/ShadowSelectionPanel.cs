using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSelectionPanel : MonoBehaviour
{
    public ShadowSlot[] shadowSlots;
    public Transform slotHolder;
    public ShadowSelectedSlot[] shadowSelectedSlots;
    public Transform selectedslotHolder;
    // Start is called before the first frame update
    void Awake()
    {
        shadowSlots = slotHolder.GetComponentsInChildren<ShadowSlot>();
        shadowSelectedSlots = selectedslotHolder.GetComponentsInChildren<ShadowSelectedSlot>();

    }
    private void Update()
    {
        
    }

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
