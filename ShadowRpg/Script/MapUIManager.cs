using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapUIManager : MonoBehaviour
{
    //キャラクター編成panel
    [SerializeField] ShadowSelectionPanel shadowSelectionPanel;
    //インベントリpanel
    [SerializeField] EquipmentPanel equipmentPanel;


    [SerializeField] Text currentMoneyText;
    bool shadowSelectionPanelOn =false;
    bool inventoryPanelOn = false;
   

    // Update is called once per frame
    void Update()
    {
        CurrentMoneyTextOn();
    }
    public void ShadowPanelOn()
    {
     
        if (!shadowSelectionPanelOn)
        {
            if (inventoryPanelOn)
            {
                equipmentPanel.gameObject.SetActive(false);
                inventoryPanelOn = false;
            }
            shadowSelectionPanel.gameObject.SetActive(true);
            shadowSelectionPanelOn = true;
        }
        else if (shadowSelectionPanelOn)
        {
            shadowSelectionPanel.gameObject.SetActive(false);
            shadowSelectionPanelOn = false;
        }
        shadowSelectionPanel.SetShadowSlot();
        shadowSelectionPanel.SetSelectedShadowSlot();
        
        }
    public void InventoryPanelOn()
    {
        Debug.Log("on");
        if (!inventoryPanelOn)
        {
            if (shadowSelectionPanelOn)
            {
                shadowSelectionPanel.gameObject.SetActive(false);
                shadowSelectionPanelOn = false;
            }
            equipmentPanel.gameObject.SetActive(true);
            inventoryPanelOn = true;
        }
        else if (inventoryPanelOn)
        {
            equipmentPanel.gameObject.SetActive(false);
            inventoryPanelOn = false;
        }
        equipmentPanel.SetEquiptmentSlot();
        equipmentPanel.SetSelectedEquiptmentSlot();
    }

    public void CurrentMoneyTextOn()
    {
        
            currentMoneyText.text = "" + Player.instance.Money;
       
    }

}
