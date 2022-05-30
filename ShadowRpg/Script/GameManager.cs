using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    public static GameManager instance = null;

    public enum MapState {Move,StageClear,StageClearNot }
    public MapState mapState;
    public GameObject MapDestination;
    public int battleLevel;
    // Start is called before the first frame update
    private void Awake()
    {
        
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        battleLevel = 1;
        mapState = MapState.Move;
    }
    // Update is called once per frame
    void Update()
    {
        MapOn();
        ChangeMoveState();
    }

    public void MapOn()
    {
        if (SceneManager.GetActiveScene().name == "MapScene")
        {
            MapSceneCanvas.instance.gameObject.SetActive(true);
        }
    }
    public void ChangeMoveState()
    {
        if (mapState == MapState.StageClear && MapDestination != null)
        {
           
                MapDestination.GetComponent<Land>().DestroyButton();
                mapState = MapState.Move;
       
        }
    }
    public void StageClear()
    {
        if (SceneManager.GetActiveScene().name == "MapScene")
        {
            ResetShadow();
            ResetEquiptment();
            GameManager.instance.mapState = GameManager.MapState.StageClear;

        }
        if (SceneManager.GetActiveScene().name != "MapScene")
        {
            ResetShadow();
            ResetEquiptment();
            mapState = MapState.Move;
          
            GameManager.instance.mapState = GameManager.MapState.StageClear;
            SceneManager.LoadScene("MapScene");
        }
       
    }
    public void ResetEquiptment()
    {
       
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {
            Player.instance.battleEquipmentList[i].gameObject.SetActive(false);
            Player.instance.battleEquipmentList[i].timer = Player.instance.battleEquipmentList[i].cooltime;

        }
    }
    public void ResetShadow()
    {
        for (int i = 0; i < Player.instance.battleShadowList.Count; i++)
        {
            Player.instance.battleShadowList[i].gameObject.SetActive(false);
            Player.instance.battleShadowList[i].targetEnemy = null;
            Player.instance.battleShadowList[i].battlePosition = null;
            Player.instance.battleShadowList[i].skillDelay = Player.instance.battleShadowList[i].skillCooltime;
            Player.instance.battleShadowList[i].actionDelay = 0;

        }
    }

    public void SwapShadow(List<Shadow> battleShadowList, int from, int to)
    {
        if (from + 1 > Player.instance.battleShadowList.Count || to + 1 > Player.instance.battleShadowList.Count)
        {

        }
        else if (from < 0 || to < 0)
        {

        }
        else
        {
            Shadow e;
            e = battleShadowList[from];
            battleShadowList[from] = battleShadowList[to];
            battleShadowList[to] = e;
        }
    }
    public void SwapEnemy(List<Enemy> battleEnemyList, int from, int to)
    {
        if (from + 1 > BattleManager.battleEnemyList.Count || to + 1 > BattleManager.battleEnemyList.Count)
        {

        }
        else if (from < 0 || to < 0)
        {

        }
        else
        {
            Enemy e;
            e = battleEnemyList[from];
            battleEnemyList[from] = battleEnemyList[to];
            battleEnemyList[to] = e;
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void GameClear()
    {
        SceneManager.LoadScene("GameClearScene");
    }

}
