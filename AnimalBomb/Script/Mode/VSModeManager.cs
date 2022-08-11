using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VSModeManager : ModeManager
{
    [Header("Trigger")]
    bool playSceneSettingActive = false;
    bool playSceneTimerActive = false;
    bool resultActive = false;

    //爆撃までの時間
    public float timeOuttimer = 100f;

    private void Start()
    {   //GameManagerの変数modeTypeをvsにする。
        GameManager.instance.modeType = GameManager.ModeType.vs;
        //GameManagerの変数modeを自分にする。
        GameManager.instance.mode = this;
    }
    //モードをセットする。
    public override void SetMode()
    {
        //プレーシーンに終了ボタンを隠す。
        GameManager.instance.playSceneExitButton.SetActive(false);
        //カメラの位置を設定する。
        if (GameManager.instance.mapSize == GameManager.MapSize.small)
        {
            GameManager.instance.playerSceneCamera.transform.localPosition = new Vector3(GameManager.instance.gridSizeX / 2, 12, 1.7f);
        }
        else if (GameManager.instance.mapSize == GameManager.MapSize.medium)
        {
            GameManager.instance.playerSceneCamera.transform.localPosition = new Vector3(GameManager.instance.gridSizeX / 2, 12f, 2.3f);

        }
        else if (GameManager.instance.mapSize == GameManager.MapSize.large)
        {
            GameManager.instance.playerSceneCamera.transform.localPosition = new Vector3(GameManager.instance.gridSizeX / 2, 14f, 2.8f);
        }
        //プレイヤーを見えるようにする。
        GameManager.instance.player.SetActive(true);
        //CPUを見えるようにする。
        for (int i = 0; i < GameManager.instance.CPUs.Count; i++)
        {
            GameManager.instance.CPUs[i].SetActive(true);
        }
        playSceneSettingActive = true;
    }
    //モードをプレーするメソッド
    public override void PlayMode()
    {
            if (!playSceneSettingActive)
            {  //モードをセットする。 
            SetMode();
            }
            if (!playSceneTimerActive)
            { //時間になるとTriggerを発動させる。
                if (timeOuttimer > 0)
                {
                    timeOuttimer -= Time.deltaTime;
                }
                if (timeOuttimer <= 0)
                {
                    playSceneTimerActive = true;
                }
            }
            if (playSceneTimerActive)
            {//爆撃を始める。
                GameManager.instance.bombardment.StartBombard(GameManager.instance.gridSizeX, GameManager.instance.gridSizeZ);
            }
        //条件に応じて終了ボタンを見えるようにする。
        ActiveExitButton();
            if (!resultActive)
        　　　{ //条件に応じてゲームの結果を出す
            ResultGame();
            }
    }
   
    public override void ResultGame()
    {
        //プレイヤーだけ残っている場合
        if (GameManager.instance.player != null && GameManager.instance.CPUs.Count == 0)
        {
            if (GameManager.instance.player.GetComponent<Player>() != null)
            {
                //プレイヤーのモデルをコピーしておく。
                GameManager.instance.resultAnimalModel = GameManager.instance.player.GetComponent<Player>().playerModelObject;
                Instantiate(GameManager.instance.resultAnimalModel, transform);
                //全ての爆撃を止める
                GameManager.instance.bombardment.StopRoof();
                Invoke("MoveResultScene", 0.5f);
                resultActive = true;
            }
        }
        //CPU一人だけ残っている場合
        else if (GameManager.instance.player == null && GameManager.instance.CPUs.Count == 1)
        {
            if (GameManager.instance.CPUs[0].GetComponent<CPU>() != null)
            {
                //CPUのモデルをコピーしておく。
                GameManager.instance.resultAnimalModel = GameManager.instance.CPUs[0].GetComponent<CPU>().cpuModelObject;
                Instantiate(GameManager.instance.resultAnimalModel, transform);
                //全ての爆撃を止める
                GameManager.instance.bombardment.StopRoof();
                Invoke("MoveResultScene", 0.5f);
                resultActive = true;
            }
        }
        //誰も残っていない場合
        else if (GameManager.instance.player == null && GameManager.instance.CPUs.Count == 0)
        {
            GameManager.instance.resultAnimalModel = null;
            //全ての爆撃を止める
            GameManager.instance.bombardment.StopRoof();
            Invoke("MoveResultScene", 0.5f);
            resultActive = true;
        }
    }
    //結果のシーンに移動する
    public override void MoveResultScene()
    {
        DestroyObject();
        SceneManager.LoadScene("ResultScene");
    }
    //ゲームをリセットする。
    public override void ResetGame()
    {
        DestroyObject();
        Destroy(SoundManager.instance.gameObject);
        Destroy(GameManager.instance.gameObject);
    }
    public override void DestroyObject()
    {
        //プレイヤーを破壊する。
        if (GameManager.instance.player != null)
        {
            Destroy(GameManager.instance.player);
        }
        //CPUを破壊する。
        for (int i = 0; i < GameManager.instance.CPUs.Count; i++)
        {
            Destroy(GameManager.instance.CPUs[i]);
        }
        //マップを破壊する。
        if (GameManager.instance.map != null)
        {
            Destroy(GameManager.instance.map);
        }
    }
    //プレイヤーがなくなると終了ボタンを見えるようにする。
    void ActiveExitButton()
    {
        if (GameManager.instance.player == null)
        {
            GameManager.instance.playSceneExitButton.SetActive(true);
        }
    }
}
