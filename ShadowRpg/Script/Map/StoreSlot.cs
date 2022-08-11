using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StoreSlot : MonoBehaviour
{
    //装備のデータベース
    [SerializeField] EquipmentDB equipmentDB;
    //キャラクターのデータベース
    [SerializeField] ShadowDB shadowDB;
    //商品
    Shadow shadowGoods;
    //商品
    Equipment equipmentGoods;
    //商品のアイコン
    [SerializeField] Image iconImage;
    //商品の情報を表すtext
    [SerializeField] Text infoText;
    //商品のお値段を表すtext
    [SerializeField] Text priceText;
    [SerializeField] Transform playerTransform;
    //商品のお値段
    public int price;
    //商品のタイプ
    public enum GoodsType {shadow,equipment}
    public GoodsType goodsType;
    int random;
    private void Start()
    {
        //まず商品を決める。
        random = Random.Range(0,2);
        if(random == 0)
        {
            goodsType  = GoodsType.shadow;
        }
        else if (random == 1)
        {
            goodsType  = GoodsType.equipment;
        }
        //商品のタイプがキャラクターの場合。
        if (goodsType == GoodsType.shadow)
        {
            random = Random.Range(0, shadowDB.shadowList.Count);
            shadowGoods = shadowDB.shadowList[random];
            iconImage.sprite = shadowGoods.shadowIcon;
            infoText.text  = "Name:" + shadowGoods.NAME + "\n" +
                                   "Level:" + shadowGoods.LEVEL + "\n" +
                                      "HP:" + (int)shadowGoods.HP + "\n" +
                                      "Damage:" + (int)shadowGoods.DAMAGE + "\n" +
                                      "Deffence:" + (int)shadowGoods.DEFFENCE+"%" + "\n" +
                                      "CoolTime:" + (int)shadowGoods.actionCooltime + "\n" +
                                      "Range:" + shadowGoods.RANGE + "\n" +
                                      "Skill:" + shadowGoods.SKILL + "\n" +
                                      "";
        }
        //商品のタイプが装備の場合。
        else if (goodsType == GoodsType.equipment)
        {
            random = Random.Range(0, equipmentDB.equiptmentList.Count);
            equipmentGoods = equipmentDB.equiptmentList[random];
            iconImage.sprite = equipmentGoods.equiptmentIcon;
            infoText.text = "Name:" + equipmentGoods.NAME + "\n" +
               "Skill:" + equipmentGoods.info + "\n";

        }
        random = Random.Range(80,160);
        price = random;
        priceText.text = "" + price;

    }
    //プレイヤーがボタンを押すと商品をプレイヤーに結ぶ。
    public void BuyGoods()
    {
   if(Player.instance.Money >= price)
        {
            Player.instance.Money -= price;
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
    }
    //商店をリセットする。
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
        random = Random.Range(40, 110);
        price = random;
        priceText.text = "" + price;

    }
   

}
