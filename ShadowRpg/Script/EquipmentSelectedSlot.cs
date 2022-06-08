using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//プレイヤーBattleEquipmentListの中の装備を表すslotクラス
public class EquipmentSelectedSlot : MonoBehaviour
{
    [SerializeField] GameObject slotImage;

    //slotのイメージを描く
    public void drawSlotSprite(Sprite sprite)
    {
        slotImage.SetActive(true);
        slotImage.GetComponent<Image>().sprite = sprite;

    }
    //slotのイメージを消す
    public void SlotImageOff()
    {
        slotImage.SetActive(false);
    }

}
