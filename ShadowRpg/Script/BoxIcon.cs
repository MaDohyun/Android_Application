using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoxIcon : MapIcon,ITriggerOn
{

    [SerializeField] BoxPanel boxPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Invoke("IconTriggerOn", 0.4f);

        }

    }
    public void IconTriggerOn()
    {

        boxPanel.gameObject.SetActive(true);
        Destroy(this.gameObject);


    }
}
