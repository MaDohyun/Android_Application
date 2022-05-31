using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour
{
    public Transform[] battleEnemyPositions = new Transform[4];
    
    public Transform[] battleShadowPositions = new Transform[3];

    [SerializeField] EnemyGenerator enemyGenerator;
    public static List<Enemy> battleEnemyList = new List<Enemy>();


    public ParticleSystem[] shadowPositionSummonEffects = new ParticleSystem[3];

    public Camera battleCamera;
    Shadow selectedShadow;

    public GameObject[] backGrounds;
    public GameObject resultImage;
    public Text resultMoneyText;

    bool isSummonEffect;
    float colorChange = 0;

    int random;
    int resultmoney;
    // Start is called before the first frame update
    void Start()
    {
       
            switch(GameManager.instance.battleLevel)
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
        if (isSummonEffect != true)
        {
            colorChange += Time.deltaTime * 0.3f;
            SetBattleShadowEffect();
        }
        if (battleEnemyList.Count == 0)
        {
            if (GameManager.instance.battleLevel == 4)
            {
                GameClear();
            }
            else
            {
                BattleVictory();
            }
        }

        if (Player.instance.battleShadowList.Count == 0)
        {
            
                Invoke("BattleLose", 0.5f);
        
        }
        SlowTimeSpeed();
        ReturnTimeSpeed();
        
    }

    public void GivePositionEnemy()
    {
        
            if (battleEnemyPositions.Length >= battleEnemyList.Count)
            {
            for (int i = 0; i < battleEnemyList.Count; i++)
            {
                battleEnemyList[i].SetBattlePosition(battleEnemyPositions[i]);
            }
            }
            else if (battleEnemyPositions.Length < battleEnemyList.Count)
            {
            for (int i = 0; i < battleEnemyPositions.Length; i++)
            {
                battleEnemyList[i].SetBattlePosition(battleEnemyPositions[i]);
            }
        }
        
        

    }
    public void GivePositionBattleShadow()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].SetBattlePosition(battleShadowPositions[i]);

        }

    }
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
    public void SetBattleEquiptment()
    {
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {
            Player.instance.battleEquipmentList[i].gameObject.SetActive(true);
        }
    }

    public void SetEnemy()
    {
        if (GameManager.instance.battleLevel == 1)
        {
           
                for (int i = 0; i < 2; i++)
                {
                    battleEnemyList.Add(enemyGenerator.GenerateLevel1Enemy());
                }
            
        }
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
        if (GameManager.instance.battleLevel == 3)
        {
            random = Random.Range(0, 8);


                for (int i = 0; i < 3; i++)
                {
                    battleEnemyList.Add(enemyGenerator.GenerateLevel3Enemy());
                }
          
           
        }
        if (GameManager.instance.battleLevel == 4)
        {
                    battleEnemyList.Add(enemyGenerator.GenerateBossEnemy1());
            battleEnemyList.Add(enemyGenerator.GenerateBossEnemy2());
            battleEnemyList.Add(enemyGenerator.GenerateBossEnemy3());
            battleEnemyList.Add(enemyGenerator.GenerateBossEnemy4());
        }


    }
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

    public void SlowTimeSpeed()
    {
        
            if (selectedShadow != null)
            {
                Time.timeScale = 0.5f;
               
            }
        
    }
    public void ReturnTimeSpeed()
    {
        if (selectedShadow == null)
        {
            Time.timeScale = 1.0f;
        }
    }

    public void MoveCamera(float cameraMoveXPosition)
    {
       
        battleCamera = battleCamera.GetComponent<Camera>();
        battleCamera.orthographicSize = 4.7f;
        battleCamera.GetComponent<Transform>().position = new Vector3(cameraMoveXPosition, battleCamera.GetComponent<Transform>().position.y, battleCamera.GetComponent<Transform>().position.z);
    }

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
    public void MoveCameraOff()
    {
        if (selectedShadow == null)
        {

            battleCamera.orthographicSize = 5;
            battleCamera.GetComponent<Transform>().position = new Vector3(0, battleCamera.GetComponent<Transform>().position.y, battleCamera.GetComponent<Transform>().position.z);
        }
    }

   



    public void BattleVictory()
    {
            resultImage.SetActive(true);
            resultMoneyText.text = resultmoney.ToString();
            Invoke("StageClear",1.5f);
   }
    public void BattleLose()
    {
      
            GameManager.instance.GameOver();
       
    }
   
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

    public void GameClear()
    {
        GameManager.instance.GameClear();
    }


}