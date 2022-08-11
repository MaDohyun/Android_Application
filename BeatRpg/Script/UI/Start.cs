using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        //PlaySceneを呼び込む
        SceneManager.LoadScene(1);
    }
}
