using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレーシーンに終了ボタン
public class PlaySceneExitButton : MonoBehaviour
{
    private void Awake()
    {//GameManagerのplaySceneExitButton変数に自分を設定する。
        GameManager.instance.playSceneExitButton = this.gameObject;
    }

}
