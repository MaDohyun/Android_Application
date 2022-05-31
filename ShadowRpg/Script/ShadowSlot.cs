using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShadowSlot : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] GameObject slotImage;
    [SerializeField] GameObject selectedBorderLine;
    [SerializeField] ShadowSelectionPanel shadowSelection;
    
    [SerializeField] ShadowLevelUpButton ShadowLevelUpButton;
    [SerializeField] ShadowInformation shadowInformation;
    Shadow shadow;
    public bool selectedOn = false;

    private void Start()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
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

    public void drawSlotSprite(Sprite sprite)
    {
        slotImage.SetActive(true);
        slotImage.GetComponent<Image>().sprite = sprite;
        
    }
    public void ResetSlot()
    {
        slotImage.SetActive(false);
        selectedBorderLine.SetActive(false);
        selectedOn = false;
    }
    public void SetShadow(Shadow shadow)
    {
        this.shadow = shadow;
    }
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShadowLevelUpButton.shadow = this.shadow;
        shadowInformation.shadow = this.shadow;
    }

}
