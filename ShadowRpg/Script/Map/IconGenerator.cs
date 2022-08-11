using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//マップのアイコンを生成するクラス
public class IconGenerator : MonoBehaviour
{
    int random;

    [SerializeField] MapIcon monsterIcon;
    [SerializeField] MapIcon heartIcon;
    [SerializeField] MapIcon storeIcon;
    [SerializeField] MapIcon moneyIcon;
    [SerializeField] MapIcon boxIcon;

    //ランダムでマップにアイコンを生成する。
    public MapIcon IconGenerate(Transform targettransform)
    {
        random = Random.Range(0, 100);
        MapIcon icon;
        if (random < 57)
        {
            icon = Instantiate(monsterIcon, targettransform.position, Quaternion.identity);
            icon.transform.SetParent(targettransform, false);
            return icon;
        }
        else if (random >= 57 && random < 69)
        {
            icon = Instantiate(storeIcon, targettransform.position, Quaternion.identity);
            icon.transform.SetParent(targettransform, false);
            return icon;
        }
        else if (random >= 69 && random < 77)
        {
            icon = Instantiate(boxIcon, targettransform.position, Quaternion.identity);
            icon.transform.SetParent(targettransform, false);
            return icon;
        }
        else if (random >= 77 && random < 86)
        {
            icon = Instantiate(moneyIcon, targettransform.position, Quaternion.identity);
            icon.transform.SetParent(targettransform, false);
            return icon;
        }
        else
        {
            icon = Instantiate(heartIcon, targettransform.position, Quaternion.identity);
            icon.transform.SetParent(targettransform, false);
            return icon;
        }
    }
    
}
