using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    
    public static GameManager instance = null;

    //マップでの状態
    public enum MapState {Move,StageClear,StageClearNot }
    public MapState mapState;
    //マップでの目的地
    public GameObject MapDestination;
    public int battleLevel;
    // シングルトーンパターンを利用
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
   
    void Update()
    {
        MapOn();
        ChangeMoveState();
        //"GameOverScene" または"GameClearScene"の時、ゲームをリセットする。
        if (SceneManager.GetActiveScene().name == "GameOverScene" || SceneManager.GetActiveScene().name == "GameClearScene")
        {
           
            GameReset();
        }
    }
    //MapSceneの場合、マップのゲームオブジェクトを見えるようにする。
    public void MapOn()
    {
        if (SceneManager.GetActiveScene().name == "MapScene")
        {
            MapSceneCanvas.instance.gameObject.SetActive(true);
        }
    }
    //目的地をクリアする場合、状態をmoveに変える。
    public void ChangeMoveState()
    {
        if (mapState == MapState.StageClear && MapDestination != null)
        {
                MapDestination.GetComponent<Land>().DestroyButton();
                mapState = MapState.Move;
        }
    }
    //目的地のクリア
    public void StageClear()
    {
        //MapSceneの場合
        if (SceneManager.GetActiveScene().name == "MapScene")
        {
            ResetShadow();
            ResetEquiptment();
            GameManager.instance.mapState = GameManager.MapState.StageClear;

        }
        //MapSceneのではない場合MapSceneを呼び込む
        if (SceneManager.GetActiveScene().name != "MapScene")
        {
            ResetShadow();
            ResetEquiptment();
            mapState = MapState.Move;
          
            GameManager.instance.mapState = GameManager.MapState.StageClear;
            SceneManager.LoadScene("MapScene");
        }
       
    }
    //プレイヤーの装備をリセット
    public void ResetEquiptment()
    {
       
        for (int i = 0; i < Player.instance.battleEquipmentList.Count; i++)
        {
            Player.instance.battleEquipmentList[i].gameObject.SetActive(false);
            Player.instance.battleEquipmentList[i].timer = Player.instance.battleEquipmentList[i].cooltime;

        }
    }
    //プレイヤーのキャラクターをリセット
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
    //プレイヤーのbattleShadowList配列の要素をswapする。
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
    //battleEnemyList配列の要素をswapする。
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
    //ゲームオーバーメソッド
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    //ゲームクリアメソッド
    public void GameClear()
    {
        SceneManager.LoadScene("GameClearScene");
    }
    //ゲームリセットメソッド、シングルトーンパターンのオブジェクトを破壊する。
    public void GameReset()
    {
        Destroy(Player.instance.gameObject);
        Destroy(MapSceneCanvas.instance.gameObject);
        Destroy(instance.gameObject);
    }

}
