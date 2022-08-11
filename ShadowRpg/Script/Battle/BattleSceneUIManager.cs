using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//バトルのUIを管理するクラス

public class BattleSceneUIManager : MonoBehaviour
{
    //選ばれたキャラクターの上にある矢印アイコン
    [SerializeField] GameObject selectedArrowIcon;
    //選ばれたキャラクターのアイコンの枠
    [SerializeField] GameObject[] shadowSelectedBorderLines = new GameObject[3];
    //キャラクターのアイコン
    [SerializeField] GameObject[] shadowIcons = new GameObject[3];
    //キャラクターのスキルアイコン
    [SerializeField] GameObject shadowSkillIcon;
    //キャラクターのスキルが活性していない時のアイコン
    [SerializeField] GameObject shadowSkillIconGray;
    //キャラクターのスキルのタイマーを表すtext
    [SerializeField] Text shadowSkillDelayText;
    //プレイヤーの装備のアイコン
    [SerializeField] GameObject[] EquitmentIcons = new GameObject[2];
    [SerializeField] GameObject leftMoveIcon;
    [SerializeField] GameObject rightMoveIcon;
    //プレイヤーの装備のタイマーを表すtext
    [SerializeField] Text[] EquitmentTexts = new Text[2];
    //選ばれたキャラクターからの矢印アイコンの距離
    Vector3 selectedArrowIconGap;
    //選ばれたキャラクター
    Shadow selectedShadow;
    private void Start()
    {
        selectedArrowIconGap = new Vector3(0, 1.77f, 0);

    }
    private void LateUpdate()
    {
        SetSelectedShadow();
        SetShadowIcons();
        SetShadowSkillIcon();
        SetSelectedBorderLine();
        SetselectedArrowIcon();
        SetEquitmentIcon();
        SetEquitmentText();
        SetMoveIcon();
        UIOff();
    }
    //キャラクターのアイコンをUIにセットする。
    public void SetShadowIcons()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            shadowIcons[i].SetActive(true);
            shadowIcons[i].GetComponent<Image>().sprite = Player.instance.battleShadowList[i].shadowIcon;
        }
    }
    //選ばれたキャラクターのスキルアイコンをUIにセットする。
    public void SetShadowSkillIcon()
    {
        if (selectedShadow != null)
        {
            //選ばれたキャラクターのskillOnがtrueの場合、スキルを使うことが可能であるため、色があるアイコンを表示する。
            if (selectedShadow.skillOn)
            {
                shadowSkillIcon.SetActive(true);
                shadowSkillIcon.GetComponent<Image>().sprite = selectedShadow.skillIcon;
                shadowSkillIconGray.SetActive(false);
                shadowSkillDelayText.gameObject.SetActive(false);
            }
            //選ばれたキャラクターのskillOnがfalseの場合、スキルを使うことが不可能であるため、色が灰色のアイコンを表示する。

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
    //選ばれたキャラクターのアイコンの枠を活性化する。
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
    //選ばれたキャラクターの上にArrowIconを表示させる。
    public void SetselectedArrowIcon()
    {
        if (selectedShadow != null)
        {
            selectedArrowIcon.SetActive(true);
            selectedArrowIcon.transform.position = selectedShadow.transform.position + selectedArrowIconGap;
        }
        else
        {
            selectedArrowIcon.SetActive(false);
        }
        
    }
    //プレイヤーの装備のアイコンをUIにセットする。
    public void SetEquitmentIcon()
    {
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {

            EquitmentIcons[i].SetActive(true);
            EquitmentIcons[i].GetComponent<Image>().sprite = Player.instance.battleEquipmentList[i].equiptmentIcon;
        }
    }
    //プレイヤーの装備のタイマーを表示させる。
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
    //選ばれたキャラクターのプレイヤーのbattleShadowList配列中の位置によってMoveIconを表示させる。
    //選ばれたキャラクターがレイヤーのbattleShadowList配列中に0番目の要素である場合、右に移動することができないためrightMoveIcon.SetActive(false)する。
    //選ばれたキャラクターがレイヤーのbattleShadowList配列中に2番目の要素である場合、左に移動することができないためrightMoveIcon.SetActive(false)する。
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
    //プレイヤーのプレイヤーのbattleShadowList配列の長さによってUIをOffさせる。
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
    //選ばれたキャラクターをセットする。
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
