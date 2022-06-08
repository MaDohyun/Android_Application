using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxSlot : MonoBehaviour
{
    //装備のデータベース
    [SerializeField] EquipmentDB equipmentDB;
    //キャラクターのデータベース
    [SerializeField] ShadowDB shadowDB;
    //宝
    Shadow shadowGoods;
    //宝
    Equipment equipmentGoods;
    //宝のアイコン
    [SerializeField] Image iconImage;
    //宝の情報を表すtext
    [SerializeField] Text infoText;
    //プレイヤーの位置
    [SerializeField] Transform playerTransform;
    //宝のタイプ
    public enum GoodsType { shadow, equipment }
    public GoodsType goodsType;
    int random;
    private void Start()
    {//まず宝を決める。
        random = Random.Range(0, 2);
        if (random == 0)
        {
            goodsType = GoodsType.shadow;
        }
        else if (random == 1)
        {
            goodsType = GoodsType.equipment;
        }
        //宝のタイプがキャラクターの場合。
        if (goodsType == GoodsType.shadow)
        {
            random = Random.Range(0, shadowDB.shadowList.Count);
            shadowGoods = shadowDB.shadowList[random];
            iconImage.sprite = shadowGoods.shadowIcon;
            infoText.text = "Name:" + shadowGoods.NAME + "\n" +
                                   "Level:" + shadowGoods.LEVEL + "\n" +
                                      "HP:" + (int)shadowGoods.HP + "\n" +
                                      "Damage:" + (int)shadowGoods.DAMAGE + "\n" +
                                      "Deffence:" + (int)shadowGoods.DEFFENCE+"%" + "\n" +
                                      "CoolTime:" + (int)shadowGoods.actionCooltime + "\n" +
                                      "Range:" + shadowGoods.RANGE + "\n" +
                                      "Skill:" + shadowGoods.SKILL + "\n" +
                                      "";
        }
        //宝のタイプが装備の場合。
        else if (goodsType == GoodsType.equipment)
        {
            random = Random.Range(0, equipmentDB.equiptmentList.Count);
            equipmentGoods = equipmentDB.equiptmentList[random];
            iconImage.sprite = equipmentGoods.equiptmentIcon;
            infoText.text = "Name:" + equipmentGoods.NAME + "\n" +
               "Skill:" + equipmentGoods.info + "\n";

        }


    }
    //プレイヤーがボタンを押すと宝をプレイヤーに結ぶ。
    public void BuyGoods()
    {
            if (goodsType == GoodsType.shadow)
            {

                Shadow newShadow = Instantiate(shadowGoods);
                newShadow.gameObject.SetActive(false);
                newShadow.transform.SetParent(playerTransform);
                Player.instance.haveShadowList.Add(newShadow);
            }
            else if (goodsType == GoodsType.equipment)
            {
                Equipment newEquipment = Instantiate(equipmentGoods);
                newEquipment.gameObject.SetActive(false);
                newEquipment.transform.SetParent(playerTransform);
                Player.instance.haveEquipmentList.Add(newEquipment);
            }
            this.gameObject.SetActive(false);
        }
    //宝箱をリセットする。

    public void ResetSlot()
    {
        random = Random.Range(0, 2);
        if (random == 0)
        {
            goodsType = GoodsType.shadow;
        }
        else if (random == 1)
        {
            goodsType = GoodsType.equipment;
        }

        if (goodsType == GoodsType.shadow)
        {
            random = Random.Range(0, shadowDB.shadowList.Count);
            shadowGoods = shadowDB.shadowList[random];
            iconImage.sprite = shadowGoods.shadowIcon;
            infoText.text = "Name:" + shadowGoods.NAME + "\n" +
                                   "Level:" + shadowGoods.LEVEL + "\n" +
                                      "HP:" + (int)shadowGoods.HP + "\n" +
                                      "Damage:" + (int)shadowGoods.DAMAGE + "\n" +
                                      "Deffence:" + (int)shadowGoods.DEFFENCE + "%" + "\n" +
                                      "CoolTime:" + (int)shadowGoods.actionCooltime + "\n" +
                                      "Range:" + shadowGoods.RANGE + "\n" +
                                      "Skill:" + shadowGoods.SKILL + "\n" +
                                      "";
        }
        else if (goodsType == GoodsType.equipment)
        {
            random = Random.Range(0, equipmentDB.equiptmentList.Count);
            equipmentGoods = equipmentDB.equiptmentList[random];
            iconImage.sprite = equipmentGoods.equiptmentIcon;
            infoText.text = "Name:" + equipmentGoods.NAME + "\n" +
               "Skill:" + equipmentGoods.info + "\n";

        }


    }
}
