using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//普通の破壊できるブロックのクラスである。
public class DestructableWall : MonoBehaviour
{

    //破壊できるブロックは破壊された後にアイテムを生成するのでアイテムDBを参照する。
    [SerializeField] ItemListDB itemListDB;
    int random;
    Item item;

    [Header("Trigger")]
    //アイテムを生成したかどうか。
    bool ItemcreateActive = false;
    private void Start()
    {
        //アイテムを生成する確率は1/3であるためアイテム全体数の3倍の中からランダム数をとる。
        random = Random.Range(0, itemListDB.itemList.Count*3);
        //アイテムを生成する。
        CreateItem();
    }
    public void OnTriggerEnter(Collider other)
    {
        //Explosion(爆発particle)と触れる場合は破壊される。
        if (other.CompareTag("Explosion"))
        {
            //Explosion(爆発particle)を消す。
            Destroy(other.gameObject);
            //すぐ破壊されると、連鎖爆発でアイテムが破壊される可能性があるため、連鎖爆発が終わる時間をまち、0.15秒後破壊される。
            Invoke("DestroyThisObject",0.15f);
        }
    }
    void DestroyThisObject()
    {
        //ブロックが破壊されるとアイテムはしばらく爆発から安全な時間を持つ
        if (item)
        {
            item.itemActive = true;
            item.notDestroyTimer = 0.5f;
        }
        Destroy(gameObject);
    }
    void CreateItem()
    { //　ランダムでアイテムリストからアイテムを生成するかそれとも生成しない。
        if (!ItemcreateActive)
        {
            if (random < itemListDB.itemList.Count)
            {
                item = Instantiate(itemListDB.itemList[random], gameObject.transform);
                item.transform.SetParent(this.transform.parent.transform);
            }
            ItemcreateActive = true;
        }
    }

}
