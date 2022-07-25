using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSModeStageCreator : MonoBehaviour
{
    [Header("Model")]
    public List<GameObject> ModelList;
    public GameObject catModel;
    public GameObject duckModel;
    public GameObject penguinModel;
    public GameObject sheepModel;
    GameObject Playermodel;

    public GameObject Player;
    public GameObject CPU1;
    public GameObject CPU2;
    public GameObject CPU3;

    [Header("Type")]
    public GameManager.MapSize mapSize;
    public GameManager.MapType mapType;
    public GameManager.CharacterType characterType;
    
    GameObject CPUmodel;
    //マップにあるflowerの数
    int flowerCount = 0;

    public Vector3 start;
    public Vector3 offset;

    [Header("Prefabs")]
    public GameObject wallPrefab;
    public GameObject innerWallPrefab;
    public GameObject destructableWallPrefab;
    public GameObject movableWallPrefab;
    public GameObject barrelPrefab;
    public GameObject flowerPrefab;
    public GameObject groundPlane;

    [Header("PlaceHolder")]
    public Transform outherwallHolder;
    public Transform innerwallHolder;
    public Transform destructablewallHolder;
    public Transform movablewallHolder;
    public Transform barrelHolder;
    public Transform flowerHolder;

    [Header("MapSize")]
    public int gridSizeX;
    public int gridSizeZ;
    
    private void Start()
    {
        //ステージの初期設定
        RegistMediumMapSize();
        RegistRandomMapType();
        RegistCatCharacterType();
        //モデルリストにモデルを登録する
        ModelList.Add(catModel);
        ModelList.Add(duckModel);
        ModelList.Add(penguinModel);
        ModelList.Add(sheepModel);
    }
    //マップのサイズを設定する。
    public void RegistSmallMapSize()
    {
        mapSize = GameManager.MapSize.small;
        gridSizeX = 13;
        gridSizeZ = 11;
    }
    public void RegistMediumMapSize()
    {
        mapSize = GameManager.MapSize.medium;
        gridSizeX = 15;
        gridSizeZ = 13;
    }
    public void RegistLargeMapSize()
    {
        mapSize = GameManager.MapSize.large;
        gridSizeX = 17;
        gridSizeZ = 15;
    }
    //マップのタイプを設定する。
    public void RegistClassicMapType()
    {
        mapType = GameManager.MapType.classic;
    }
    public void RegistRandomMapType()
    {
        mapType = GameManager.MapType.random;
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
        GameManager.instance.mapType = this.mapType;
        GameManager.instance.mapSize = this.mapSize;
        GameManager.instance.characterType = this.characterType;
        GameManager.instance.gridSizeX = this.gridSizeX;
        GameManager.instance.gridSizeZ = this.gridSizeZ;
    }
    //マップを作るメソッド
    public void CreateMap()
    {
        BuildBorder();
        BuildInnerWalls();
        BuildBlock();
        SetPlayer(new Vector3(start.x+1,start.y,start.z+1));
        SetCPU(CPU1, new Vector3(start.x + 1, start.y, gridSizeZ-2));
        SetCPU(CPU2, new Vector3(gridSizeX - 2, start.y, gridSizeZ - 2));
        SetCPU(CPU3, new Vector3(gridSizeX - 2, start.y, start.z + 1));
    }
    //壁を作るメソッド
    public void BuildBorder()
    {
        //壁はマップサイズの境界線に沿って生成する。
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeZ; j++)
            {
                if (i == 0 || i == gridSizeX - 1)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3(start.x + i + offset.x, start.y + offset.y,
                            start.z + j + offset.z);
                    wall.transform.parent = outherwallHolder;
                }
                if (j == 0 || j == gridSizeZ - 1)
                {
                    GameObject wall = Instantiate(wallPrefab);
                    wall.transform.position = new Vector3(start.x + i + offset.x, start.y + offset.y, start.z + j + offset.z);
                    wall.transform.parent = outherwallHolder;
                }
            }
        }
        ResizeGroundPlane();
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
        groundPlane.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeX, gridSizeZ);
    }
    //中の壁を作るメソッド(座標i値が偶数で、座標jが偶数である場合)
    void BuildInnerWalls()
    {
        int random;
        for (int i = 2; i < gridSizeX - 1; i++)
        {
            for (int j = 2; j < gridSizeZ - 1; j++)
            {
                if ((i % 2) == 0 && (j % 2) == 0)
                {
                    //座標i値が偶数で、座標jが偶数である場合
                    //マップタイプがclassicの場合は壁だけを生成する。
                    if (mapType == GameManager.MapType.classic)
                    {
                        GameObject wall = Instantiate(innerWallPrefab);
                        wall.transform.position = new Vector3(start.x + i + offset.x,
                                start.y + offset.y,
                                start.z + j + offset.z);
                        wall.transform.parent = innerwallHolder;
                    }
                    //座標i値が偶数で、座標jが偶数である場合
                    //マップタイプがrandomの場合は壁や様々なブロックを生成する。
                    else if (mapType == GameManager.MapType.random)
                    {
                        random = Random.Range(0, 20);
                        if (random < 16)
                        {
                            GameObject wall = Instantiate(innerWallPrefab);
                            wall.transform.position = new Vector3(start.x + i + offset.x,
                                    start.y + offset.y,
                                    start.z + j + offset.z);
                            wall.transform.parent = innerwallHolder;
                        }
                        else if (random == 16)
                        {
                            GameObject wall = Instantiate(movableWallPrefab);
                            wall.transform.position = new Vector3(start.x + i + offset.x,
                                    start.y + offset.y,
                                    start.z + j + offset.z);
                            wall.transform.parent = movablewallHolder;
                        }
                        else if (random == 17)
                        {
                            GameObject wall = Instantiate(flowerPrefab);
                            wall.transform.position = new Vector3(start.x + i + offset.x,
                                    start.y + offset.y,
                                    start.z + j + offset.z);
                            wall.transform.parent = flowerHolder;
                            flowerCount++;
                            //flowerはマップに3以上あるとその後追加されたのは破壊される。
                            if (flowerCount > 3)
                            {
                                Destroy(wall);
                            }
                        }
                        
                    }
                }
            }
        }
    }
    //中のブロックを作るメソッド
    void BuildBlock()
    {
        int random;

        for (int i = 2; i < gridSizeX - 2; i++)
        {
            for (int j = 1; j < gridSizeZ - 1; j++)
            {
                if ((i % 2) == 0 && (j % 2) == 1)
                {
                    if ((i == 2 && j == 1))
                    {
                    }
                    else if ((i == 2 && j == gridSizeZ - 2))
                    {

                    }
                    else if ((i == gridSizeX - 3 && j == gridSizeZ - 2))
                    {

                    }
                    else if ((i == gridSizeX - 3 && j == 1))
                    {

                    }
                    else
                    {
                        //座標i値が偶数で、座標jが奇数である場合
                        //マップタイプがclassicの場合は壁だけを生成する。
                        if (mapType == GameManager.MapType.classic)
                        {
                            GameObject wall = Instantiate(destructableWallPrefab);
                            wall.transform.position = new Vector3(start.x + i + offset.x,
                                    start.y + offset.y,
                                    start.z + j + offset.z);
                            wall.transform.parent = destructablewallHolder;
                        }
                        //座標i値が偶数で、座標jが奇数である場合
                        //マップタイプがrandomの場合は壁や様々なブロックを生成する。
                        if (mapType == GameManager.MapType.random)
                        {
                            random = Random.Range(0, 15);
                            if (random < 10)
                            {
                                GameObject wall = Instantiate(destructableWallPrefab);
                                wall.transform.position = new Vector3(start.x + i + offset.x,
                                        start.y + offset.y,
                                        start.z + j + offset.z);
                                wall.transform.parent = destructablewallHolder;
                            }
                            else if (random == 11)
                            {
                                GameObject wall = Instantiate(barrelPrefab);
                                wall.transform.position = new Vector3(start.x + i + offset.x,
                                        start.y + offset.y,
                                        start.z + j + offset.z);
                                wall.transform.parent = barrelHolder;
                            }

                        }
                    }
                }
            }

        }
        for (int i = 1; i < gridSizeX - 1; i++)
        {
            for (int j = 1; j < gridSizeZ - 1; j++)
            {
                if ((i % 2) == 1)
                {
                    if ((i == 1 && j == 1) || (i == 1 && j == 2))
                    {

                    }
                    else if ((i == 1 && j == gridSizeZ - 2) || (i == 1 && j == gridSizeZ - 3))
                    {

                    }
                    else if ((i == gridSizeX - 2 && j == gridSizeZ - 2) || (i == gridSizeX - 2 && j == gridSizeZ - 3))
                    {

                    }
                    else if ((i == gridSizeX - 2 && j == 1) || (i == gridSizeX - 2 && j == 2))
                    {

                    }
                    else
                    {
                        //座標i値が奇数である場合
                        //マップタイプがclassicの場合は壁だけを生成する。
                        if (mapType == GameManager.MapType.classic)
                        {
                            GameObject wall = Instantiate(destructableWallPrefab);
                            wall.transform.position = new Vector3(start.x + i + offset.x, start.y + offset.y,
                                    start.z + j + offset.z);
                            wall.transform.parent = destructablewallHolder;
                        }
                        //座標i値が奇数である場合
                        //マップタイプがrandomの場合は壁や様々なブロックを生成する。
                        if (mapType == GameManager.MapType.random)
                        {
                            random = Random.Range(0, 21);
                            if (random < 14)
                            {
                                GameObject wall = Instantiate(destructableWallPrefab);
                                wall.transform.position = new Vector3(start.x + i + offset.x, start.y + offset.y,
                                        start.z + j + offset.z);
                                wall.transform.parent = destructablewallHolder;
                            }
                            else if (random == 15)
                            {
                                GameObject wall = Instantiate(movableWallPrefab);
                                wall.transform.position = new Vector3(start.x + i + offset.x,
                                        start.y + offset.y,
                                        start.z + j + offset.z);
                                wall.transform.parent = movablewallHolder;
                            }
                            else if (random == 16)
                            {
                                GameObject wall = Instantiate(flowerPrefab);
                                wall.transform.position = new Vector3(start.x + i + offset.x,
                                        start.y + offset.y,
                                        start.z + j + offset.z);
                                wall.transform.parent = flowerHolder;
                                flowerCount++;
                                //flowerはマップに3以上あるとその後追加されたのは破壊される。
                                if (flowerCount > 3)
                                {
                                    Destroy(wall);
                                    wall = Instantiate(innerWallPrefab);
                                    wall.transform.position = new Vector3(start.x + i + offset.x,
                                            start.y + offset.y,
                                            start.z + j + offset.z);
                                    wall.transform.parent = innerwallHolder;
                                }
                            }
                            else if (random == 17)
                            {
                                GameObject wall = Instantiate(barrelPrefab);
                                wall.transform.position = new Vector3(start.x + i + offset.x,
                                        start.y + offset.y,
                                        start.z + j + offset.z);
                                wall.transform.parent = barrelHolder;
                            }
                        }
                    }

                }
            }
        }
    }
    //プレイヤーを設定するメソッド
    void SetPlayer(Vector3 startPosition)
    {
        switch (characterType)
         {
            case GameManager.CharacterType.cat:
                //モデルを瀬生する
                Playermodel = Instantiate(catModel,Player.transform);
                //モデルをリストに追加する。
                ModelList.RemoveAt(ModelList.IndexOf(catModel));
                //キャラクターによって能力を与える。
                Player.GetComponent<Player>().playerSpeed = 2.8f;
                break;
            case GameManager.CharacterType.duck:
                Playermodel = Instantiate(duckModel, Player.transform);
               ModelList.RemoveAt(ModelList.IndexOf(duckModel));
                Player.GetComponent<Player>().playerExplosionAmount = 2;
                break;
            case GameManager.CharacterType.penguin:
                Playermodel = Instantiate(penguinModel, Player.transform);
               ModelList.RemoveAt(ModelList.IndexOf(penguinModel));
                Player.GetComponent<Player>().playerExplosionPower = 3;
                break;
            case GameManager.CharacterType.sheep:
                Playermodel = Instantiate(sheepModel, Player.transform);
                ModelList.RemoveAt(ModelList.IndexOf(sheepModel));
                break;
         }
        //プレイヤーをセットする。
        Player.GetComponent<Player>().playerModelObject = Playermodel;
        Player.transform.position = startPosition;
        DontDestroyOnLoad(Player);
    }
    //CPUを設定するメソッド
    void SetCPU(GameObject cpu,Vector3 startPosition)
    {
        int random = Random.Range(0, ModelList.Count);
        CPUmodel = Instantiate(ModelList[random], cpu.transform);
        ModelList.RemoveAt(random);
        cpu.GetComponent<CPU>().cpuModelObject = CPUmodel;
        cpu.transform.position = startPosition;
        DontDestroyOnLoad(cpu);
    }

}
