using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレーシーンのカメラ
public class PlaySceneCamera : MonoBehaviour
{
    //GameManagerのplayerSceneCamera変数に自分を設定する。
    private void Awake()
    {
        GameManager.instance.playerSceneCamera = GetComponent<Camera>();
    }
}
