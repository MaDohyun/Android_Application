using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleSceneUIManager : MonoBehaviour
{


    [SerializeField] GameObject selectedShadowIcon;
    [SerializeField] GameObject[] shadowSelectedBorderLines = new GameObject[3];
    [SerializeField] GameObject[] shadowIcons = new GameObject[3];
    [SerializeField] GameObject shadowSkillIcon;
    [SerializeField] GameObject shadowSkillIconGray;
    [SerializeField] Text shadowSkillDelayText;
    [SerializeField] GameObject[] EquitmentIcons = new GameObject[2];
    [SerializeField] GameObject leftMoveIcon;
    [SerializeField] GameObject rightMoveIcon;
    [SerializeField] Text[] EquitmentTexts = new Text[2];

    Vector3 selectedIconGap;

    Shadow selectedShadow;
    private void Start()
    {
        selectedIconGap = new Vector3(0, 1.77f, 0);

    }
    private void LateUpdate()
    {
        SetSelectedShadow();
        SetShadowIcons();
        SetShadowSkillIcon();
        SetSelectedBorderLine();
        SetSelectedShadowIcon();
        SetEquitmentIcon();
        SetEquitmentText();
        SetMoveIcon();
        UIOff();
    }
    public void SetShadowIcons()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {

            shadowIcons[i].SetActive(true);
            shadowIcons[i].GetComponent<Image>().sprite = Player.instance.battleShadowList[i].shadowIcon;

        }
    }

    public void SetShadowSkillIcon()
    {
        if (selectedShadow != null)
        {
            if (selectedShadow.skillOn)
            {
                shadowSkillIcon.SetActive(true);
                shadowSkillIcon.GetComponent<Image>().sprite = selectedShadow.skillIcon;
                shadowSkillIconGray.SetActive(false);
                shadowSkillDelayText.gameObject.SetActive(false);
            }
            else
            {
                shadowSkillIcon.SetActive(false);
                shadowSkillIconGray.SetActive(true);
                shadowSkillIconGray.GetComponent<Image>().sprite = selectedShadow.skillIcon;
                shadowSkillDelayText.gameObject.SetActive(true);
                shadowSkillDelayText.text = "" + (int)selectedShadow.skillDelay;
            }
           
        }
       
        else
        {
            shadowSkillIconGray.SetActive(false);
            shadowSkillIcon.SetActive(false);
            shadowSkillDelayText.gameObject.SetActive(false);
        }
    }
    public void SetSelectedBorderLine()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            if (Player.instance.battleShadowList[i].isSelected)
            {
                shadowSelectedBorderLines[i].SetActive(true);
            }
            else
            {
                shadowSelectedBorderLines[i].SetActive(false);
            }
        }

    }
    public void SetSelectedShadowIcon()
    {
        if (selectedShadow != null)
        {
            selectedShadowIcon.SetActive(true);
            selectedShadowIcon.transform.position = selectedShadow.transform.position + selectedIconGap;
        }
        else
        {
            selectedShadowIcon.SetActive(false);
        }
        
    }
    public void SetEquitmentIcon()
    {
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {

            EquitmentIcons[i].SetActive(true);
            EquitmentIcons[i].GetComponent<Image>().sprite = Player.instance.battleEquipmentList[i].equiptmentIcon;
        }
    }
    public void SetEquitmentText()
    {
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {
            if (Player.instance.battleEquipmentList[i].equiptType == Equipment.EquiptType.active)
            {
                EquitmentTexts[i].text = "" + (int)Player.instance.battleEquipmentList[i].timer;
            }
            else if (Player.instance.battleEquipmentList[i].equiptType == Equipment.EquiptType.passive)
            {
                EquitmentTexts[i].text = "∞";
            }
        }
    }
    public void SetMoveIcon()
    {
        for(int i=0; i < Player.instance.battleShadowList.Count; i++)
        {
            if(selectedShadow == Player.instance.battleShadowList[i])
            {
                if(i+1 == Player.instance.battleShadowList.Count)
                {
                    leftMoveIcon.SetActive(false);
                    rightMoveIcon.SetActive(true);
                }
                else if (i==0)
                {
                    leftMoveIcon.SetActive(true);
                    rightMoveIcon.SetActive(false);
                }
                else 
                {
                    leftMoveIcon.SetActive(true);
                    rightMoveIcon.SetActive(true);
                }

            }
            
        }
        
       
    }
    public void UIOff()
    {
        switch (Player.instance.battleShadowList.Count)
        {
            case 0:
                shadowIcons[0].SetActive(false);
                shadowSelectedBorderLines[0].SetActive(false);
                shadowIcons[1].SetActive(false);
                shadowSelectedBorderLines[1].SetActive(false);
                shadowIcons[2].SetActive(false);
                shadowSelectedBorderLines[2].SetActive(false);
                break;
            case 1:
                shadowIcons[1].SetActive(false);
                shadowSelectedBorderLines[1].SetActive(false);
                shadowIcons[2].SetActive(false);
                shadowSelectedBorderLines[2].SetActive(false);
                break;
            case 2:
                shadowIcons[2].SetActive(false);
                shadowSelectedBorderLines[2].SetActive(false);
                break;
            default:

                break;
        }
    }
    public void SetSelectedShadow()
    {
       
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            if (Player.instance.battleShadowList[i].isSelected)
            {
                selectedShadow = Player.instance.battleShadowList[i];
                return;
            }

        }
        selectedShadow = null;
       
    }
}
