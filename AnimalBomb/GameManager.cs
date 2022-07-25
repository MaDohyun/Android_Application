using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ゲームの情報を持っているGameManagerクラス
public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    //ステージの情報
    //ステージの大きさ
    public enum MapSize { small, medium, large }
    //ステージのタイプ
    public enum MapType { classic, random }
    //キャラクターモデルのタイプ
    public enum CharacterType { cat, duck, penguin, sheep }
    //モードのタイプ
    public enum ModeType { vs, survival }
    public MapSize mapSize;
    public MapType mapType;
    public CharacterType characterType;
    public ModeType modeType;

    //プレイヤーシーンのカメラ
    public Camera playerSceneCamera;
    //ステージのサイズ
    public int gridSizeX;
    public int gridSizeZ;

    //プレイヤー
    public GameObject player;
    //CPUリスト
    public List<GameObject> CPUs = new List<GameObject>();

    //モード
    public ModeManager mode;

    [Header("PlaceHolder")]
    public Transform outherwallHolder;
    public Transform innerwallHolder;
    public Transform destructablewallHolder;
    public Transform movablewallHolder;

    //ゲームを終わらせるボーたん
    public GameObject playSceneExitButton;
    //結果シーンに出るモデル。
    public GameObject resultAnimalModel;
    //爆撃
    public Bombardment bombardment;
    //マップう
    public GameObject map;

    //シングルトンを用いる。
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
    //GameManagerはプレーシーンになるとモードをプレーさせる
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            mode.PlayMode();
        }
    }
    
}
