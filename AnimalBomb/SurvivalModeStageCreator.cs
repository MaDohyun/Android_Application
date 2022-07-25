using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalModeStageCreator : MonoBehaviour
{
    public GameObject Player;

    [Header("Model")]
    public List<GameObject> ModelList;
    public GameObject catModel;
    public GameObject duckModel;
    public GameObject penguinModel;
    public GameObject sheepModel;
    GameObject Playermodel;

    [Header("Vector")]
    public Vector3 start;
    public Vector3 offset;

    [Header("Prefabs")]
    public GameObject wallPrefab;

    public GameObject groundPlane;
    [Header("PlaceHolder")]
    public Transform outherwallHolder;

    [Header("MapSize")]
    public int gridSizeX = 9;
    public int gridSizeZ = 7;

    public GameManager.CharacterType characterType;

    private void Start()
    {//キャラクターの初期タイプ
       characterType = GameManager.CharacterType.cat;
    }

    //キャラクターのタイプを設定する。
    public void RegistCatCharacterType()
    {
        characterType = GameManager.CharacterType.cat;
    }
    public void RegistDuckCharacterType()
    {
        characterType = GameManager.CharacterType.duck;
    }

    public void RegistPenguinCharacterType()
    {
        characterType = GameManager.CharacterType.penguin;
    }

    public void RegistSheepCharacterType()
    {
        characterType = GameManager.CharacterType.sheep;
    }
    //ステージを作るメソッド
    public void CreateStage()
    {
        CreateMap();
        //GameManagerにステージ情報を渡す。
        GameManager.instance.characterType = this.characterType;
        GameManager.instance.gridSizeX = this.gridSizeX;
        GameManager.instance.gridSizeZ = this.gridSizeZ;
    }
    //マップを作るメソッド
    public void CreateMap()
    {
        BuildBorder();
        ResizeGroundPlane();
        SetPlayer(new Vector3(gridSizeX/2, start.y, gridSizeX/2));
    }
    //壁を作るメソッド
    public void BuildBorder()
    {
        //壁はマップサイズより1より大きい境界線に沿って生成する。
        for (int i = -1; i < gridSizeX+1; i++)
        {
            for (int j = -1; j < gridSizeZ+1; j++)
            {
                if (i == -1 || i == gridSizeX )
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3(start.x + i + offset.x, start.y + offset.y,
                            start.z + j + offset.z);
                    wall.transform.parent = outherwallHolder;
                }
                if (j == -1 || j == gridSizeZ)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3(start.x + i + offset.x, start.y + offset.y, start.z + j + offset.z);
                    wall.transform.parent = outherwallHolder;
                }
            }
        }
    }
    //床をサイズに応じて再設定する
    void ResizeGroundPlane()
    {
        Vector3 scaler = new Vector3((float)gridSizeX / 10, 1, (float)gridSizeZ / 10);
        //床の大きさ
        groundPlane.transform.localScale = scaler;
        //床の位置
        groundPlane.transform.transform.position = new Vector3(gridSizeX / 2, 0, gridSizeZ / 2);
        //床のtiling
        groundPlane.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(4.5f, 3.5f);
    }
    //プレイヤーを設定するメソッド
    void SetPlayer(Vector3 startPosition)
    {
        switch (characterType)
        {
            case GameManager.CharacterType.cat:
                Playermodel = Instantiate(catModel, Player.transform);
                break;
            case GameManager.CharacterType.duck:
                Playermodel = Instantiate(duckModel, Player.transform);
                break;
            case GameManager.CharacterType.penguin:
                Playermodel = Instantiate(penguinModel, Player.transform);
                break;
            case GameManager.CharacterType.sheep:
                Playermodel = Instantiate(sheepModel, Player.transform);
                break;
        }
        //決まったモデルをプレイヤーにモデルにする。
        Player.GetComponent<Player>().playerModelObject = Playermodel;
        Player.transform.position = startPosition;
        DontDestroyOnLoad(Player);
    }
   
}
