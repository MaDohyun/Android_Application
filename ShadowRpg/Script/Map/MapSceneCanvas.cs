using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapSceneCanvas : MonoBehaviour
{
    // シングルトーンパターンを利用
    public static MapSceneCanvas instance = null;
    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
                    }
    }
    void Update()
    {//MapSceneではない場合このオブジェクトを見えないようにする。
        if (SceneManager.GetActiveScene().name != "MapScene")
        {
            this.gameObject.SetActive(false);
        }
    }

    }
