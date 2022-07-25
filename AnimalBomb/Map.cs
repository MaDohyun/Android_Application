using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//マップクラス
public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        //GameManagerの変数に自分を設定する。
        GameManager.instance.map = this.gameObject;
    }

}
