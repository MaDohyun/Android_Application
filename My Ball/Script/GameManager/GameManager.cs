using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //ステージのコイン数
    public int TotalCoinCount;
    //クリアしたStageのナンバー
    public int stageClearNumber;
    public BallManager ballManager;
    //Ball
    public GameObject player;
    //ステージ2に行く前の壁
    public GameObject stage1wall;
    //ステージ3のfloor
    public GameObject Stage3_floor_normal;
    public GameObject Stage3_floor_red;
    //ステージ4のfloor
    public GameObject Stage4_floor_normal;
    public GameObject Stage4_floor_red;
    //ステージ3の踏むと最初の場所に戻る赤いタイルのコライダー
    public GameObject stage3redCollider;
    //ステージ4の踏むと最初の場所に戻る赤いタイルのコライダー
    public GameObject stage4redCollider;
    //ステージ3の壁
    public GameObject stage3goalwall1;
    public GameObject stage3goalwall2;
    public GameObject stage3goalwall3;
    public GameObject stage3goalwall4;
    //ステージ4の動くfloor
    public GameObject stage4transcube;
    //現在のステージナンバー
    private int StageNumber = 1;
    //プレイヤーのステージの元の位置
    public Vector3 stage1position;
    public Vector3 stage2position;
    public Vector3 stage3position;
    public Vector3 stage4position;
    //ステージがクリアであるか判断
    private bool stageclear;
    //trueになるとステージ3の赤いタイルをSetActive(true)にする
    private bool stage3trigger;
    //trueになるとステージ4の赤いタイルをSetActive(true)にする
    private bool stage4trigger;
    //trueになるとステージ4の動くfloorをうごかす
    private bool transcubetrigger;
    //プレイヤーが落ちる時、やり直す深さ
    public float faildepth;
    //ステージのコインの数を表すText
    public Text stageCoinCountText;
    //ステージの情報を表すText
    public Text stageinformationText;
    float timer = 0;
    private void Awake()
    {
        stage3goalwall4.SetActive(false);
        Stage3_floor_red.SetActive(false);
        Stage4_floor_red.SetActive(false);
        stage3trigger = false;
        stage4trigger = false;
        transcubetrigger = false;
        stageclear = false;
        stageCoinCountText.text = ballManager.coinCount+"/"+TotalCoinCount;
       
    }
   
    private void Update()
    {
        //現在のステージナンバーが1の場合
        if (StageNumber == 1)
        {
            //ステージにあるコインの数と集めたコインの数を表す。
            stageCoinCountText.text = ballManager.coinCount + "/" + TotalCoinCount;
            //ステージの情報を表す。
            stageinformationText.text = "spaceキーを押してコインを集め!";
            //プレイヤーが落ちる場合ステージの始まりの場所に戻る。
            if (ballManager.playerposition.y < faildepth)
            {
                player.transform.position = stage1position;
            }
        }
        //現在のステージナンバーが２の場合
        if (StageNumber == 2)
        {//ステージの情報を表す。
            stageinformationText.text = "ボックスを踏んで上に上がれ!";
            //プレイヤーが落ちる場合ステージの始まりの場所に戻る。
            if (ballManager.playerposition.y < faildepth)
            {
                player.transform.position = stage2position;
            }
        }
        //現在のステージナンバーが３の場合
        if (StageNumber == 3)
        {//timerを作動させる。
            timer += Time.deltaTime;
            //ステージの情報を表す。
            stageinformationText.text = "赤色を避けて進め!";
            //timerによって赤いタイルを作動させる。
            if (timer > 2 && stage3trigger == false)
            {//Stage3_1には赤いタイルがない。
                Stage3_floor_normal.SetActive(false);
                //Stage3_2には赤いタイルがある。
                Stage3_floor_red.SetActive(true);
                stage3redCollider.SetActive(true);
                stage3trigger = true;
                timer = 0;
            }
            //timerによって赤いタイルを作動させる。
            if (timer > 2 && stage3trigger)
            {
                Stage3_floor_normal.SetActive(true);
                Stage3_floor_red.SetActive(false);
                stage3redCollider.SetActive(false);
                stage3trigger = false;
                timer = 0;
            }
            //プレイヤーが落ちる場合ステージの始まりの場所に戻る。
            if (ballManager.playerposition.y < faildepth)
            {
                player.transform.position = stage3position;
            }
        }
        //現在のステージナンバーが４の場合
        if (StageNumber == 4)
        {
            timer += Time.deltaTime;
            stageCoinCountText.text = ballManager.coinCount + "/" + TotalCoinCount;
            stageinformationText.text = "コインを20個集めて決まったゴール地点まで行け!";
            stage3goalwall4.SetActive(true);
            stage3goalwall3.SetActive(false);
            //timerによって動きfloorを作動させる。
            if (timer > 2 && stage4trigger == false)
            {//Stage4_1には赤いタイルがない。
                Stage4_floor_normal.SetActive(false);
                //Stage4_2には赤いタイルがある。
                Stage4_floor_red.SetActive(true);
                stage4redCollider.SetActive(true);
                stage4trigger = true;
                timer = 0;
                transcubetrigger = true;
            }
            //timerによって動きfloorを作動させる。
            if (timer <2 && transcubetrigger ==false)
            {
                stage4transcube.transform.position += Vector3.up * Time.deltaTime *5;
                
            }
            //timerによって赤いタイルを作動させる。
            if (timer > 2 && stage4trigger)
            {
                Stage4_floor_normal.SetActive(true);
                Stage4_floor_red.SetActive(false);
                stage4redCollider.SetActive(false);
                stage4trigger = false;
                timer = 0;
                transcubetrigger = false;
            }
            //timerによって赤いタイルを作動させる。
            if (timer < 2 && transcubetrigger)
            {
                stage4transcube.transform.position += Vector3.down * Time.deltaTime * 5;
                
            }
            //プレイヤーが落ちる場合ステージの始まりの場所に戻る。
            if (ballManager.playerposition.y < faildepth)
            {
                player.transform.position = stage4position;
            }
            

        }
       }
    void LateUpdate()
    {//コインをTotalCoinの数ほど集めるとstage1のクリア
        if (ballManager.coinCount == TotalCoinCount && StageNumber == 1)
        {
            StageNumber = 2;
            stageclear = true;
        }
        //ステージ2をクリアするとステージ2に行く前の壁がなくなる。
        if (StageNumber == 2 && stageclear)
        {
            stage1wall.gameObject.SetActive(false);
            stageCoinCountText.text = "";
            TotalCoinCount = 20;
            ballManager.resetcoinCount();
            stageclear = false;
        }
        //ステージ2をクリアすると現在のステージナンバーが３になる。
        if (stageClearNumber == 2)
        {
            StageNumber = 3;
        }
        //ステージ3をクリアすると現在のステージナンバーが4になる。

        if (stageClearNumber == 3)
        {
            StageNumber = 4;
        }
        //ステージ4をクリアするとゲームクリアシ-ンに移動。
        if (stageClearNumber == 4)
        {
            SceneManager.LoadScene("GameClearScene");
        }

    }
   
}
