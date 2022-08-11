using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    //MapSceneを呼び込む。
    public void Startgame()
    {
        SceneManager.LoadScene("MapScene");
    }
}
