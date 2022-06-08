using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneManager : MonoBehaviour
{

    //MapSceneを呼び込む
    public void nextScene()
    {
        SceneManager.LoadScene("MapScene");
    }

}
