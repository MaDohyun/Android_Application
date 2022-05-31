using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyIcon : MapIcon
{
    [SerializeField] int randommoney;
    [SerializeField] Text text;
    private void Start()
    {
        randommoney = Random.Range(0, 61);
        text.text = randommoney.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("IconTriggerOn", 0.4f);
            
        }

    }
    public void IconTriggerOn()
    {

        Player.instance.Money += randommoney;
        Destroy(this.gameObject);
        GameManager.instance.StageClear();

    }
}
