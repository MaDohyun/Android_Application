using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//バトルを管理するクラス
public class BattleManager : MonoBehaviour
{
    //バトル中の敵の位置
    public Transform[] battleEnemyPositions = new Transform[4];
    //バトル中のキャラクターの位置
    public Transform[] battleShadowPositions = new Transform[3];

    [SerializeField] EnemyGenerator enemyGenerator;
    //バトルする敵の配列
    public static List<Enemy> battleEnemyList = new List<Enemy>();

    //バトルが始まる時キャラクター登場の効果
    public ParticleSystem[] shadowPositionSummonEffects = new ParticleSystem[3];
    //バトル中のカメラ
    public Camera battleCamera;
    //選ばれたキャラクター
    Shadow selectedShadow;

    public GameObject[] backGrounds;
    //バトルが終わった時の結果イメージ
    public GameObject resultImage;
    //バトルが終わった時の結果イメージに表示されるお金のtext
    public Text resultMoneyText;
    //バトルが始まる時キャラクター登場の効果があったかどうか
    bool isSummonEffect;
    //バトルが始まる時キャラクター登場の効果の色変化

    float colorChange = 0;

    int random;
    //バトルが終わった時の結果イメージに表示されるお金
    int resultmoney;
    void Start()
    {
        //バトルのレベルによって補償お金が変わる。
        switch (GameManager.instance.battleLevel)
        {
            case 1:
                resultmoney = Random.Range(30, 51);
                break;
            case 2:
                resultmoney = Random.Range(50, 71);
                break;
            case 3:
                resultmoney = Random.Range(70, 91);
                break;

        }
       
        resultImage.SetActive(false);
        SetBackGround();
        SetEnemy();
        SetBattleShadow();
        SetBattleEquiptment();
    }

    // Update is called once per frame
    void Update()
    {
        SetSelectedShadow();
        GivePositionEnemy();
        GivePositionBattleShadow();
        //バトルが始まる時キャラクター登場の効果がまだの場合効果を実行させる。
        if (isSummonEffect != true)
        {
            colorChange += Time.deltaTime * 0.3f;
            SetBattleShadowEffect();
        }
        if (battleEnemyList.Count == 0)
        {
            //ボスのステージで敵がいない場合ゲームクリア
            if (GameManager.instance.battleLevel == 4)
            {
                GameClear();
            }
            //敵がいない場合バトルクリア
            else
            {
                BattleVictory();
            }
        }

        if (Player.instance.battleShadowList.Count == 0)
        {
            //キャラクターが全部倒れた場合ゲームオーバー
            Invoke("BattleLose", 0.5f);
        
        }
        SlowTimeSpeed();
        ReturnTimeSpeed();
        
    }
    //敵にバトル中に位置を与える。
    public void GivePositionEnemy()
    {
        
            if (battleEnemyPositions.Length >= battleEnemyList.Count)
            {
            for (int i = 0; i < battleEnemyList.Count; i++)
            {
                battleEnemyList[i].SetBattlePosition(battleEnemyPositions[i]);
            }
            }
        //登場できる敵は与えられるバトルのいちの数より多ければならない

        else if (battleEnemyPositions.Length < battleEnemyList.Count)
            {
            for (int i = 0; i < battleEnemyPositions.Length; i++)
            {
                battleEnemyList[i].SetBattlePosition(battleEnemyPositions[i]);
            }
        }
        
    }
    //キャラクターにバトル中に位置を与える。
    public void GivePositionBattleShadow()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].SetBattlePosition(battleShadowPositions[i]);

        }

    }
    //PlayerのbattleShadowList配列の中にあるキャラクターをSetActive(true)して位置を与えて、登場効果を適用する。
    public void SetBattleShadow()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].gameObject.SetActive(true);
            Player.instance.battleShadowList[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
          
                Vector3 vector3 = new Vector3(battleShadowPositions[i].transform.position.x,
                    Player.instance.battleShadowList[i].transform.position.y,
                    Player.instance.battleShadowList[i].transform.position.z);
                Player.instance.battleShadowList[i].transform.position = vector3;
                shadowPositionSummonEffects[i].Play();
        }
       
    }
    //キャラクターの登場効果、キャラクターは影であるコンセプトなので、登場する時は色がなかったが、だんだん色が濃くなる。
    public void SetBattleShadowEffect()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].GetComponent<SpriteRenderer>().color = new Color(colorChange, colorChange, colorChange, colorChange);
        }
        if (colorChange >= 1)
        {
            colorChange = 1;
            for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
            {
                Player.instance.battleShadowList[i].GetComponent<SpriteRenderer>().color = new Color(colorChange, colorChange, colorChange, colorChange);
            }
            isSummonEffect = true;
        }

    }
    //PlayerのbattleEquipmentList配列の中なる装備オブジェクトをSetActive(true)にする。
    public void SetBattleEquiptment()
    {
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {
            Player.instance.battleEquipmentList[i].gameObject.SetActive(true);
        }
    }
    //バトルレベルによって敵を生成する。
    public void SetEnemy()
    {
        //敵を２匹生成する。

        if (GameManager.instance.battleLevel == 1)
        {
                for (int i = 0; i < 2; i++)
                {
                    battleEnemyList.Add(enemyGenerator.GenerateLevel1Enemy());
                }
            
        }
        //敵をランダムに2~3匹生成する。
        if (GameManager.instance.battleLevel == 2)
        {
            random = Random.Range(0, 8);
            if (random < 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    battleEnemyList.Add(enemyGenerator.GenerateLevel2Enemy());
                }
            }
            else 
            {
                for (int i = 0; i < 3; i++)
                {
                    battleEnemyList.Add(enemyGenerator.GenerateLevel2Enemy());
                }
            }
           
        }
        //敵を3匹生成する。

        if (GameManager.instance.battleLevel == 3)
        {
            random = Random.Range(0, 8);


                for (int i = 0; i < 3; i++)
                {
                    battleEnemyList.Add(enemyGenerator.GenerateLevel3Enemy());
                }
          
           
        }
        //ボスステージの場合、決められた敵を生成する。

        if (GameManager.instance.battleLevel == 4)
        {
                    battleEnemyList.Add(enemyGenerator.GenerateBossEnemy1());
            battleEnemyList.Add(enemyGenerator.GenerateBossEnemy2());
            battleEnemyList.Add(enemyGenerator.GenerateBossEnemy3());
            battleEnemyList.Add(enemyGenerator.GenerateBossEnemy4());
        }


    }
    //バトルレベルによって背景を変える。
    public void SetBackGround()
    {
        for (int i = 0; i < backGrounds.Length; i++)
        {
            backGrounds[i].SetActive(false);
        }
                switch(GameManager.instance.battleLevel)
            {
            case 1:
                backGrounds[0].SetActive(true);
                break;
            case 2:
                backGrounds[1].SetActive(true);
                break;
            case 3:
                backGrounds[2].SetActive(true);
                break;
            case 4:
                backGrounds[2].SetActive(true);
                break;
        }
    }
    //選ばれたキャラクターをセットする。
    public void SetSelectedShadow()
    {

        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            if (Player.instance.battleShadowList[i].isSelected)
            {
                selectedShadow = Player.instance.battleShadowList[i];
                return;
            }

        }
        selectedShadow = null;

    }
    //選ばれたキャラクターがいる場合ゲームのスピードが遅くなる。
    public void SlowTimeSpeed()
    {
        
            if (selectedShadow != null)
            {
                Time.timeScale = 0.5f;
               
            }
        
    }
    //選ばれたキャラクターがいない場合ゲームのスピードを戻す。
    public void ReturnTimeSpeed()
    {
        if (selectedShadow == null)
        {
            Time.timeScale = 1.0f;
        }
    }
    //カメラを動かせる。
    public void MoveCamera(float cameraMoveXPosition)
    {
        battleCamera = battleCamera.GetComponent<Camera>();
        battleCamera.orthographicSize = 4.7f;
        battleCamera.GetComponent<Transform>().position = new Vector3(cameraMoveXPosition, battleCamera.GetComponent<Transform>().position.y, battleCamera.GetComponent<Transform>().position.z);
    }
    //選ばれたキャラクターがいる場合カメラを動かせる。
    public void MoveCameraSelectedShadow()
    {
        if (selectedShadow != null)
        {
            for(int i=0; i< Player.instance.battleShadowList.Count; i++)
            {
                if(Player.instance.battleShadowList[i] == selectedShadow)
                {
                    MoveCamera(-i * 0.2f);
                }
            }
        }
    }
    //選ばれたキャラクターがいない場合カメラを戻す。
    public void MoveCameraOff()
    {
        if (selectedShadow == null)
        {

            battleCamera.orthographicSize = 5;
            battleCamera.GetComponent<Transform>().position = new Vector3(0, battleCamera.GetComponent<Transform>().position.y, battleCamera.GetComponent<Transform>().position.z);
        }
    }
    //バトルから勝った場合
    public void BattleVictory()
    {
            resultImage.SetActive(true);
            resultMoneyText.text = resultmoney.ToString();
        //お金の補償を見せるためにちょっと後StageClear()メソッドを呼ぶ。
        Invoke("StageClear",1.5f);
   }
    //バトルから負けた場合
    public void BattleLose()
    {
            GameManager.instance.GameOver();

    }
    //バトルから勝った場合ステージをクリアとする。
    public void StageClear()
    {
        Player.instance.Money += resultmoney;
        resultmoney = 0;
        GameManager.instance.StageClear();
    }
    private void LateUpdate()
    {
        MoveCameraSelectedShadow();
        MoveCameraOff();
        
    }
    //ボスモンスターとの戦いから勝った場合はBattleVictory()ではなくGameClear()になる。
    public void GameClear()
    {
        GameManager.instance.GameClear();
    }


}