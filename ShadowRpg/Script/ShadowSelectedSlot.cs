using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//プレイヤーBattleShadowListの中のキャラクターを表すslotクラス
public class ShadowSelectedSlot : MonoBehaviour
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
