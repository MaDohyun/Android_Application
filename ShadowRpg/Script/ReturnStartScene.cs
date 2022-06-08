using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnStartScene : MonoBehaviour
{
    //StartSceneを呼び込む
    public void ReturnStart()
    {
        SceneManager.LoadScene("StartScene");

    }
}
