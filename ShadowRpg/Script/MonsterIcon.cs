using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonsterIcon : MapIcon,ITriggerOn

{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Invoke("IconTriggerOn", 0.4f);

        }

    }
    public void IconTriggerOn()
{
    
        Destroy(this.gameObject);
        SceneManager.LoadScene("BattleScene");

}


}
