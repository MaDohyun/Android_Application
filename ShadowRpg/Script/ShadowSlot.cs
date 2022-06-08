using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//プレイヤーhaveShadowListの中のキャラクターを表すslotクラス
public class ShadowSlot : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] GameObject slotImage;
    [SerializeField] GameObject selectedBorderLine;
    [SerializeField] ShadowSelectionPanel shadowSelection;
    
    [SerializeField] ShadowLevelUpButton ShadowLevelUpButton;
    [SerializeField] ShadowInformation shadowInformation;
    Shadow shadow;
    //trueになるとプレイヤーBattleShadowListにいれる。
    public bool selectedOn = false;

    private void Start()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            //もともとこのキャラクターがBattleShadowListの中にある場合
            if (Player.instance.battleShadowList[i] == shadow)
            {
                selectedOn = true;
            }
        }
    }
    private void Update()
    {
        if (selectedOn)
        { 
           
                selectedBorderLine.SetActive(true);
          
        }
        else if (!selectedOn)
        {
            selectedBorderLine.SetActive(false);
        }
    }
    //slotのイメージを描く

    public void drawSlotSprite(Sprite sprite)
    {
        slotImage.SetActive(true);
        slotImage.GetComponent<Image>().sprite = sprite;
        
    }
    //slotのイメージをリセット
    public void ResetSlot()
    {
        slotImage.SetActive(false);
        selectedBorderLine.SetActive(false);
        selectedOn = false;
    }
    //このslotのキャラクターをセットする。

    public void SetShadow(Shadow shadow)
    {
        this.shadow = shadow;
    }
    //もともとbattleShadowList中にある場合は枠を活性化させる。
    public void SetselectedBorderLine()
    {
        for (int i=0;i< Player.instance.battleShadowList.Count;i++)
        {
            if (Player.instance.battleShadowList[i] == this.shadow)
            {
                selectedOn = true;
                selectedBorderLine.SetActive(true);
            }
        }
    }
    //ボタンを押すとこのslotのキャラクターをbattleShadowList中に入れる。
    public void RegisterShadow()
    {
        if (this.shadow != null)
        {
            for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
            {
                if (Player.instance.battleShadowList[i] == shadow)
                {
                    selectedOn = true;
                }
            }
            if (!selectedOn)
            {

                if (Player.instance.battleShadowList.Count < 3)
                {
                    selectedOn = true;
                    Player.instance.battleShadowList.Add(shadow);
                    shadowSelection.SetSelectedShadowSlot();

                }
            }
            //もともとbattleShadowList中にある場合は
            else if (selectedOn)
            {

                for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
                {
                    if (Player.instance.battleShadowList[i] == shadow)
                    {
                        Player.instance.battleShadowList.RemoveAt(i);
                        selectedOn = false;
                        shadowSelection.SetSelectedShadowSlot();
                    }
                }
            }
        }
      
    }
    //マウスを近づくと情報が出る。
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShadowLevelUpButton.shadow = this.shadow;
        shadowInformation.shadow = this.shadow;
    }

}
