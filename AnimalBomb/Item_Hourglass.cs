using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Hourglass : Item
{
    public void OnTriggerEnter(Collider other)
    {
        //VSモードの場合
        if (GameManager.instance.modeType == GameManager.ModeType.vs)
        {
            if (itemActive)
            {
                //アイテムは爆発に触れるとなくなる
                if (other.CompareTag("Explosion") && notDestroyActive)
                {
                    Destroy(this.gameObject);
                }
                //プレイヤーに触れると爆撃のタイマーが減少する。
                if (other.CompareTag("Player"))
                {
                    GameManager.instance.mode.GetComponent<VSModeManager>().timeOuttimer -= 30;
                    //プレイヤーがアイテムを得るときの音を流す。
                    SoundManager.instance.PlayGetItemSound();
                    Destroy(gameObject);
                }
                //CPUに触れると爆撃のタイマーが減少する。
                else if (other.CompareTag("CPU"))
                {
                    GameManager.instance.mode.GetComponent<VSModeManager>().timeOuttimer -= 30;
                    Destroy(gameObject);
                }
            }
        }
    }
}
