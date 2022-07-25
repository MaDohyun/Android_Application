using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//モードの上位抽象クラス
public abstract class ModeManager : MonoBehaviour
{
    public abstract void SetMode();
    public abstract void PlayMode();
    public abstract void ResultGame();
    public abstract void MoveResultScene();
    public abstract void DestroyObject();
    public abstract void ResetGame();
}
