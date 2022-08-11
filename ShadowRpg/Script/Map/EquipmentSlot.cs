using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//プレイヤーhaveEquipmentListの中の装備を表すslotクラス
public class EquipmentSlot : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] GameObject slotImage;
    [SerializeField] GameObject selectedBorderLine;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] EquipmentInformation equipmentInformation;
    Equipment equipment;
    //trueになるとプレイヤーBattleEquipmentListにいれる。
    bool selectedOn = false;
    private void Start()
    {
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {
            //もともとこの装備がBattleEquipmentListの中にある場合
            if (Player.instance.battleEquipmentList[i] == equipment)
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
    //slotのイメージを消す

    public void SlotImageOff()
    {
        slotImage.SetActive(false);
    }
    //このslotの装備をセットする。
    public void SetEquiptment(Equipment equipment)
    {
        this.equipment = equipment;
    }

    //ボタンを押すとこのslotの装備をbattleEquipmentList中に入れる。
    public void RegisterEquiptment()
    {
        if (equipment != null)
        {
            for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
            {
                if (Player.instance.battleEquipmentList[i] == equipment)
                {
                    selectedOn = true;
                }
            }
            if (!selectedOn)
            {
                if (Player.instance.battleEquipmentList.Count < 2)
                {
                    Player.instance.battleEquipmentList.Add(equipment);
                    selectedOn = true;
                    equipmentPanel.SetSelectedEquiptmentSlot();

                }
            }
            //もともとbattleEquipmentList中にある場合はbattleEquipmentListの中から抜く。
            else if (selectedOn)
            {

                for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
                {
                    if (Player.instance.battleEquipmentList[i] == equipment)
                    {
                        Player.instance.battleEquipmentList.RemoveAt(i);
                        selectedOn = false;
                        equipmentPanel.SetSelectedEquiptmentSlot();
                    }
                }
            }
        }
        equipmentInformation.equipment = this.equipment;


    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        equipmentInformation.equipment = this.equipment;
    }
}


