using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class EquipmentSlot : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField] GameObject slotImage;
    [SerializeField] GameObject selectedBorderLine;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] EquipmentInformation equipmentInformation;
    Equipment equipment;

    bool selectedOn = false;
    private void Start()
    {
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {
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

    public void drawSlotSprite(Sprite sprite)
    {
        slotImage.SetActive(true);
        slotImage.GetComponent<Image>().sprite = sprite;
        
    }
    public void SlotImageOff()
    {
        slotImage.SetActive(false);
    }
    public void SetEquiptment(Equipment equipment)
    {
        this.equipment = equipment;
    }
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


