using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Settingシーンのテキスト管理クラス
public class SurvivalSettingTextManager : MonoBehaviour
{
   
    public Text CharacterTypeText;
    public SurvivalModeStageCreator stageCreator;

    private void Update()
    {
        reTextCharacterType();
    }
    //UIのボタンを押してキャラクターを選ぶたびにテキストを変える。
    void reTextCharacterType()
    {
        if (stageCreator.characterType == GameManager.CharacterType.cat)
        {
            CharacterTypeText.text = "Character Type : Cat";
               
        }
        if (stageCreator.characterType == GameManager.CharacterType.duck)
        {
            CharacterTypeText.text = "Character Type : Duck";
         
        }
        if (stageCreator.characterType == GameManager.CharacterType.penguin)
        {
            CharacterTypeText.text = "Character Type : Penguin";
        }
        if (stageCreator.characterType == GameManager.CharacterType.sheep)
        {
            CharacterTypeText.text = "Character Type : Sheep";
        }
    }
}
