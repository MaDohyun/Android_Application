using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartIcon : MapIcon
{
    [SerializeField] int Cure;
    [SerializeField] Text text;
    private void Start()
    {
        Cure = Random.Range(10, 21);
        text.text = Cure.ToString();
    }
    
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //プレイヤーに当たるとCureほどプレイヤーのhaveShadowList配列中のキャラクターを全て回復
            Invoke("IconTriggerOn", 0.4f);
            
        }
    }
    
    public void IconTriggerOn()
    {
        for(int i=0; i< Player.instance.haveShadowList.Count; i++)
        {
            Player.instance.haveShadowList[i].HP += Cure;
        }
        Destroy(this.gameObject);
        GameManager.instance.StageClear();

    }
}
