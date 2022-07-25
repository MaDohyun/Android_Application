using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    //モードのリセット機能を呼び込む。
    public void resetGame()
    {
        GameManager.instance.mode.ResetGame();
    }
    

}
