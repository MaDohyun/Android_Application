using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMapSceneButton : MonoBehaviour
{


    //MapSceneを呼び込む
    public void MoveMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }

}
