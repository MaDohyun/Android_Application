using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReStart : MonoBehaviour
{
   
    public void ReplayGame()
    {
        //StartSceneに移動する。
        SceneManager.LoadScene(0);
      
    }
}
