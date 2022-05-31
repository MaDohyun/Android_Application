using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleKeyController : MonoBehaviour
{
    Shadow selectedShadow;
    [SerializeField] GameObject[] defenceShields = new GameObject[3];

    Vector3 defenceShieldGap;
    float cameraMoveXPosition;
    int random;
    [SerializeField] GameObject runImage;
    [SerializeField] Text runText;
    float runCoolTime = 5;
    float runDelay;
    bool isRunOn = true;
    private void Start()
    {
        for (int i = 0; i < defenceShields.Length; i++)
        {
            defenceShields[i].SetActive(false);
        }
        defenceShieldGap = new Vector3(0, 0.25f, 0);

    }
    // Update is called once per frame
    void Update()
    {
        if(runDelay > 0)
        {
            runDelay -= Time.deltaTime;
        }
        if(runDelay <= 0)
        {
            runImage.SetActive(true);
            isRunOn = true;
        }
        SetSelectedShadow();

        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
            {
                if (i == 0)
                {
                    if (!Player.instance.battleShadowList[i].isSelected)
                    {
                        Player.instance.battleShadowList[i].isSelected = true;

                    }
                    else
                    {
                        Player.instance.battleShadowList[i].isSelected = false;

                    }
                }
                else
                {
                    Player.instance.battleShadowList[i].isSelected = false;

                }
            }

        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
            {
                if (i == 1)
                {
                    if (!Player.instance.battleShadowList[i].isSelected)
                    {
                        Player.instance.battleShadowList[i].isSelected = true;
                       
                    }
                    else
                    {
                        Player.instance.battleShadowList[i].isSelected = false;

                    }
                }
                else
                {
                    Player.instance.battleShadowList[i].isSelected = false;

                }
            }

        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
            {
                if (i == 2)
                {
                    if (!Player.instance.battleShadowList[i].isSelected)
                    {
                        Player.instance.battleShadowList[i].isSelected = true;
                        
                    }
                    else
                    {
                        Player.instance.battleShadowList[i].isSelected = false;

                    }
                }
                else
                {
                    Player.instance.battleShadowList[i].isSelected = false;

                }
            }

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (selectedShadow != null && selectedShadow.actionOn)
            {
                for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
                {
                    if (selectedShadow == Player.instance.battleShadowList[i])
                    {
                        if (i+1 != Player.instance.battleShadowList.Count)
                        {
                            GameManager.instance.SwapShadow(Player.instance.battleShadowList, i, i + 1);
                            selectedShadow.isSelected = false;
                            selectedShadow.actionOn = false;
                            selectedShadow.actionDelay = 0;
                            return;
                        }

                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (selectedShadow != null && selectedShadow.actionOn )
            {
                for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
                {
                    if (selectedShadow == Player.instance.battleShadowList[i])
                    {
                        if (i != 0)
                        {
                            GameManager.instance.SwapShadow(Player.instance.battleShadowList, i, i - 1);
                            selectedShadow.isSelected = false;
                            selectedShadow.actionOn = false;
                            selectedShadow.actionDelay = 0;
                            return;
                        }
                         
                    }
                }
            }

        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (GameManager.instance.battleLevel == 4)
            {
                runText.text = "0%";
            }
            else
            {
                if (isRunOn)
                {
                    random = Random.Range(0, 4);
                    if (random == 0)
                    {
                        GameManager.instance.StageClear();
                        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
                        {
                            BattleManager.battleEnemyList = new List<Enemy>();
                            Player.instance.battleShadowList[i].targetEnemy = null;
                            Player.instance.battleShadowList[i].battlePosition = null;
                        }

                    }
                    else
                    {
                        runImage.SetActive(false);
                        runDelay = runCoolTime;
                    }
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.I))
        {
            if (selectedShadow != null)
            {
                selectedShadow.AttackAnime();
                selectedShadow.isSelected = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (selectedShadow != null)
            {
                selectedShadow.DefendAnime();
                if (selectedShadow.actionState == Shadow.ActionState.Defend)
                {

                    switch (selectedShadow.battlePositionNumber)
                    {
                        case 1:
                            defenceShields[0].SetActive(true);
                            break;
                        case 2:
                            defenceShields[1].SetActive(true);
                            break;
                        case 3:
                            defenceShields[2].SetActive(true);
                            break;
                    }

                }
                selectedShadow.isSelected = false;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (selectedShadow != null && selectedShadow.actionOn&&selectedShadow.skillOn)
            {
                selectedShadow.SkillAnime();
                selectedShadow.isSelected = false;
            }

            }

        ShiledOff();
        
    }
    public void ShiledOff()
    {
        switch (Player.instance.battleShadowList.Count)
        {
            case 0:
                defenceShields[0].SetActive(false);
                defenceShields[1].SetActive(false);
                defenceShields[2].SetActive(false);
                break;
            case 1:
                defenceShields[1].SetActive(false);
                defenceShields[2].SetActive(false);
                break;
            case 2:
                defenceShields[2].SetActive(false);
                break;
            default:

                break;
        }
        for (int i=0;i< Player.instance.battleShadowList.Count;i++)
        {
            if (Player.instance.battleShadowList[i].actionState != Shadow.ActionState.Defend)
            {
                defenceShields[i].SetActive(false);
            }
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

}
