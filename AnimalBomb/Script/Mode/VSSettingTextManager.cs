using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Settingシーンのテキスト管理クラス
public class VSSettingTextManager : MonoBehaviour
{
    public Text MapSizeText;
    public Text MapTypeText;
    public Text CharacterTypeText;
    public Text StatusText;
    public VSModeStageCreator stageCreator;

    private void Update()
    {
        reTextMapSize();
        reTextMapType();
        reTextCharacterType();
    }
    //UIのボタンを押して選ぶたびにテキストを変える。
    void reTextMapSize()
    {
        if (stageCreator.mapSize == GameManager.MapSize.small)
        {
            MapSizeText.text = "Map Size : Small";
        }
        if (stageCreator.mapSize == GameManager.MapSize.medium)
        {
            MapSizeText.text = "Map Size : Medium";
        }
        if (stageCreator.mapSize == GameManager.MapSize.large)
        {
            MapSizeText.text = "Map Size : Large";
        }
    }
    void reTextMapType()
    {
        if (stageCreator.mapType == GameManager.MapType.classic)
        {
            MapTypeText.text = "Map Type : Classic";
        }
        if (stageCreator.mapType == GameManager.MapType.random)
        {
            MapTypeText.text = "Map Type : Random";
        }
    }
    void reTextCharacterType()
    {
        if (stageCreator.characterType == GameManager.CharacterType.cat)
        {
            CharacterTypeText.text = "Character Type : Cat";
            StatusText.text = "Power : ★\n" +
                "BombAmount : ★\n"+
                "Speed : ★★";
        }
        if (stageCreator.characterType == GameManager.CharacterType.duck)
        {
            CharacterTypeText.text = "Character Type : Duck";
            StatusText.text = "Power : ★\n" +
                "BombAmount : ★★\n" +
                "Speed : ★";
        }
        if (stageCreator.characterType == GameManager.CharacterType.penguin)
        {
            CharacterTypeText.text = "Character Type : Penguin";
            StatusText.text = "Power : ★★\n" +
                "BombAmount : ★\n" +
                "Speed : ★";
        }
        if (stageCreator.characterType == GameManager.CharacterType.sheep)
        {
            CharacterTypeText.text = "Character Type : Sheep";
            StatusText.text = "Power : ★\n" +
                "BombAmount : ★\n" +
                "Speed : ★";
        }
    }
}
