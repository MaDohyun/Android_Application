using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentSelectedSlot : MonoBehaviour
{
    [SerializeField] GameObject slotImage;


    public void drawSlotSprite(Sprite sprite)
    {
        slotImage.SetActive(true);
        slotImage.GetComponent<Image>().sprite = sprite;

    }
    public void SlotImageOff()
    {
        slotImage.SetActive(false);
    }

}
