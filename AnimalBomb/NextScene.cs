using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//シーンの名前を入力してそのシーンを呼び込むクラス。
public class NextScene : MonoBehaviour
{
    public string sceneName;
    public void nextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
