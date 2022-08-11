using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoxIcon : MapIcon,ITriggerOn
{

    [SerializeField] BoxPanel boxPanel;
    //プレイヤーが当たる場合宝箱のPanelを見えるようにする。
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
        //機能が終わったらアイコンを破壊する。
        Destroy(this.gameObject);
    }
}
