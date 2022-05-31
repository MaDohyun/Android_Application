using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreIcon :  MapIcon,ITriggerOn
{
    [SerializeField] StorePanel storePanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Invoke("IconTriggerOn", 0.4f);

        }

    }
    public void IconTriggerOn()
    {
        
        storePanel.gameObject.SetActive(true);
        Destroy(this.gameObject);
      

    }
}