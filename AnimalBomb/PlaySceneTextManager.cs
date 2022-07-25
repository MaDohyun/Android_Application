using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaySceneTextManager : MonoBehaviour
{
    //プレーシーンのテキスト
    public Text text;

    [Header("Trigger")]
    bool DangerActive = false;
    // Update is called once per frame
    void Update()
    {
        //VSモードの場合
        if (GameManager.instance.modeType == GameManager.ModeType.vs)
        {
            if (!DangerActive)
            {
                //爆撃時間になる前までは爆撃までの残っている時間を表示する。
                if (GameManager.instance.mode.GetComponent<VSModeManager>().timeOuttimer > 0)
                {
                    text.text = "Time Out : " + (int)GameManager.instance.mode.GetComponent<VSModeManager>().timeOuttimer;
                }
                //爆撃時間になるとDanger!という文字を表示する
                else
                {
                    string str = "<color=#DB4455>" + "Danger!" + "</color>";
                    text.text = str;
                    DangerActive = true;
                }
            }
        }
        //Survivalモードの場合
        else
        {//スコアを表示する。
            text.text = "Score : " + (int)GameManager.instance.mode.GetComponent<SurvivalModeManager>().score;
        }
    }

}
