using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StoreSlot : MonoBehaviour
{
    [SerializeField] EquipmentDB equipmentDB;
    [SerializeField] ShadowDB shadowDB;

    Shadow shadowGoods;
    Equipment equipmentGoods;

    [SerializeField] Image iconImage;
    [SerializeField] Text infoText;
    [SerializeField] Text priceText;
    [SerializeField] Transform playerTransform;

    public int price;
    public enum GoodsType {shadow,equipment}
    public GoodsType goodsType;
    int random;
    private void Start()
    {
        random = Random.Range(0,2);
        if(random == 0)
        {
            goodsType  = GoodsType.shadow;
        }
        else if (random == 1)
        {
            goodsType  = GoodsType.equipment;
        }

        if(goodsType == GoodsType.shadow)
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
