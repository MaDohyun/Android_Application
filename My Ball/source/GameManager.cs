using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{ 
    public int TotalCoinCount;
    public BallManager ballManager;
    public GameObject player;
    public GameObject stage1wall;
    public GameObject Stage3_1;
    public GameObject Stage3_2;
    public GameObject Stage4_1;
    public GameObject Stage4_2;
    public GameObject redtrigger;
    public GameObject stage4redtrigger;
    public GameObject stage3goalwall1;
    public GameObject stage3goalwall2;
    public GameObject stage3goalwall3;
    public GameObject stage3goalwall4;
    public GameObject stage4transcube;
   
    private int StageNumber = 1;
    public Vector3 stage1position;
    public Vector3 stage2position;
    public Vector3 stage3position;
    public Vector3 stage4position;
    private bool stageclear;
    private bool stage3trigger;
    private bool stage4trigger;
    private bool transcubetrigger;
    public float faildepth;
    public Text stageCoinCountText;
    public Text stageinformationText;
    float timer = 0;
    private void Awake()
    {
        stage3goalwall4.SetActive(false);
        Stage3_2.SetActive(false);
        Stage4_2.SetActive(false);
        stage3trigger = false;
        stage4trigger = false;
        transcubetrigger = false;
        stageclear = false;
        stageCoinCountText.text = ballManager.coinCount+"/"+TotalCoinCount;
       
    }
    void LateUpdate()
    {
       if(ballManager.coinCount == TotalCoinCount && StageNumber ==1)
        {
            StageNumber = 2;
            stageclear = true;
        }
       if(StageNumber==2 && stageclear)
        {
            stage1wall.gameObject.SetActive(false);
            stageCoinCountText.text = "";
            TotalCoinCount = 20;
            ballManager.resetcoinCount();
            stageclear = false;
        }
       if(ballManager.stageclear == 2)
        {
            StageNumber = 3;
        }
        if (ballManager.stageclear == 3)
        {
            StageNumber = 4;
        }
        if (ballManager.stageclear == 4 && ballManager.coinCount>TotalCoinCount)
        {
            SceneManager.LoadScene("GameClearScene");
        }
        if (ballManager.stageclear == 4 && ballManager.coinCount < TotalCoinCount)
        {
            player.transform.position = stage4position;
            ballManager.notclearstage4();
        }
    }
    private void Update()
    {
        
        if (StageNumber == 1)
        {
            stageCoinCountText.text = ballManager.coinCount + "/" + TotalCoinCount;
            stageinformationText.text = "spaceキーを押してコインを集め!";
            if (ballManager.playerposition.y < faildepth)
            {
                player.transform.position = stage1position;
            }
        }
        if (StageNumber == 2)
        {
            stageinformationText.text = "ボックスを踏んで上に上がれ!";
            if (ballManager.playerposition.y < faildepth)
            {
                player.transform.position = stage2position;
            }
        }
        if (StageNumber == 3)
        {
            timer += Time.deltaTime;
            stageinformationText.text = "赤色を避けて進め!";
            if (timer > 2 && stage3trigger == false)
            {
                Stage3_1.SetActive(false);
                Stage3_2.SetActive(true);
                redtrigger.SetActive(true);
                stage3trigger = true;
                timer = 0;
            }
            if (timer > 2 && stage3trigger)
            {
                Stage3_1.SetActive(true);
                Stage3_2.SetActive(false);
                redtrigger.SetActive(false);
                stage3trigger = false;
                timer = 0;
            }
            if (ballManager.playerposition.y < faildepth)
            {
                player.transform.position = stage3position;
            }
        }
        if (StageNumber == 4)
        {
            timer += Time.deltaTime;
            stageCoinCountText.text = ballManager.coinCount + "/" + TotalCoinCount;
            stageinformationText.text = "コインを20個集めて決まったゴール地点まで行け!";
            stage3goalwall4.SetActive(true);
            stage3goalwall3.SetActive(false);

            if (timer > 2 && stage4trigger == false)
            {
                Stage4_1.SetActive(false);
                Stage4_2.SetActive(true);
                stage4redtrigger.SetActive(true);
                stage4trigger = true;
                timer = 0;
                transcubetrigger = true;
            }
            if (timer <2 && transcubetrigger ==false)
            {
                stage4transcube.transform.position += Vector3.up * Time.deltaTime *5;
                
            }
            if (timer > 2 && stage4trigger)
            {
                Stage4_1.SetActive(true);
                Stage4_2.SetActive(false);
                stage4redtrigger.SetActive(false);
                stage4trigger = false;
                timer = 0;
                transcubetrigger = false;
            }
            if (timer < 2 && transcubetrigger)
            {
                stage4transcube.transform.position += Vector3.down * Time.deltaTime * 5;
                
            }

            if (ballManager.playerposition.y < faildepth)
            {
                player.transform.position = stage4position;
            }
            

        }
       }
    public bool gettranscubetrigger()
    {
        return transcubetrigger;
    }
}
