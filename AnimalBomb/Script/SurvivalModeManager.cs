using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SurvivalModeManager : ModeManager
{
    [Header("Trigger")]
    bool playSceneSettingActive = false;
    bool resultActive = false;

    //Survivalモードのスコア
    public float score;

    private void Start()
    {
        //GameManagerの変数modeTypeをsurvivalにする。
        GameManager.instance.modeType = GameManager.ModeType.survival;
        //GameManagerの変数modeを自分にする。
        GameManager.instance.mode = this;
    }
    //モードをセットする。
    public override void SetMode()
    {
        //カメラの位置を設定する。
        GameManager.instance.playerSceneCamera.transform.localPosition = new Vector3(GameManager.instance.gridSizeX / 2, 10, 1);
        //爆撃クラスを設定する。
        GameManager.instance.bombardment.fallingExplosionPower = 10;
        GameManager.instance.bombardment.fallingExplosionTime = 3;

        //プレイヤーのモデルをコピーしておく。
        GameManager.instance.resultAnimalModel = GameManager.instance.player.GetComponent<Player>().playerModelObject;
        GameObject model = Instantiate(GameManager.instance.resultAnimalModel, transform);
        model.SetActive(false);
        //プレイヤーを見えるようにする。
        GameManager.instance.player.SetActive(true);
        playSceneSettingActive = true;
    }
    //モードをプレーするメソッド
    public override void PlayMode()
    {
        if (!playSceneSettingActive)
            {//モードをセットする。
                SetMode();
            }
        //爆撃を始める。
            GameManager.instance.bombardment.StartBombard(GameManager.instance.gridSizeX, GameManager.instance.gridSizeZ);
        //スコアを計算する。
        score += Time.deltaTime*10;
        if (!resultActive)
        {
            //条件に応じてゲームの結果を出す
            ResultGame();
        }
    }
    public override void ResultGame()
    {
        //プレイヤーがなくなった場合
        if (GameManager.instance.player == null)
        {
            //全ての爆撃を止める
                GameManager.instance.bombardment.StopRoof();
            //0.1秒後で結果のシーンに移動する。
                Invoke("MoveResultScene", 0.1f);
                resultActive = true;
        }
    }
    //結果のシーンに移動する
    public override void MoveResultScene()
    {
        //モードプレーで使ったオブジェクトを破壊する
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
        //マップを破壊する。
        if (GameManager.instance.map != null)
        {
            Destroy(GameManager.instance.map);
        }
    }
    
}
