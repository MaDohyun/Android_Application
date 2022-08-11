using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombardment : MonoBehaviour
{
    [Header("PlaceHolder")]
    public Transform bombardmentbombHolder;
    public Transform bombardmentfallingthingHolder;

    bool bombardActive = true;
    //リセットをするためにcoroutineのリストにcoroutineを保存する。
    List<Coroutine> coroutines = new List<Coroutine>();

    public GameObject fallingBombPrefab;
    //落ちる爆弾を設定する。
    public int fallingExplosionPower { get; set; } = 4;
    public int fallingExplosionAmount { get; set; } = 8;
    public int fallingExplosionTime{ get; set; } = 4;

    //Survivalモードで爆弾意外に落ちる物
    [SerializeField] List<GameObject> fallingThings;
    //落ちる物の量
    public int fallingThingAmount { get; set; } = 2;

    private void Awake()
    {
        //GameManagerの変数に自分の設定する。
        GameManager.instance.bombardment = this;
    }
    //爆撃を始める。
    public void StartBombard(int gridSizeX, int gridSizeZ)
    {
        //VSモードの場合
        if (GameManager.instance.modeType == GameManager.ModeType.vs)
        {
            if (bombardActive)
            {
                coroutines.Add(StartCoroutine(CreateBombardmentBombs(gridSizeX, gridSizeZ)));
            }
        }
        //Survivalモードの場合
        else if (GameManager.instance.modeType == GameManager.ModeType.survival)
        {
            if (bombardActive)
            {
                coroutines.Add(StartCoroutine(CreateBombardmentBombs(gridSizeX, gridSizeZ)));
                coroutines.Add(StartCoroutine(CreateFallingThing(gridSizeX, gridSizeZ)));
            }
        }
    }
    //マップのサイズに応じて爆撃する。
    private IEnumerator CreateBombardmentBombs(int gridSizeX, int gridSizeZ)
    {
        int randomx;
        int randomz;
        bombardActive = false;
        //ループは決まってる数だけする。
        for (int createBombCount = 0; createBombCount < fallingExplosionAmount;)
        {
            //マップのサイズに応じて爆撃する。
            randomx = Random.Range(1, gridSizeX - 1);
            randomz = Random.Range(1, gridSizeZ - 1);
            transform.position = new Vector3(randomx, 7, randomz);
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit, 9);
            //地面に床しかない場合爆撃する。
            if ((hit.collider && hit.collider.tag == "Ground"))
            {
                GameObject timeOutBomb = Instantiate(fallingBombPrefab, transform.position, fallingBombPrefab.transform.rotation);
                //爆弾を設定する。
                timeOutBomb.GetComponent<Bomb>().explosionTime = fallingExplosionTime;
                timeOutBomb.GetComponent<Bomb>().explosionPower = fallingExplosionPower;
                timeOutBomb.GetComponent<Collider>().isTrigger = false;
                timeOutBomb.GetComponent<Bomb>().maker = this.gameObject;
                timeOutBomb.transform.SetParent(bombardmentbombHolder.transform);
                
                createBombCount++;
            }
            //爆弾作りは0.5秒ごとにする。
            yield return new WaitForSeconds(0.5f);
        }
        //ループごとに落ちる物の数が増える。
        fallingExplosionAmount += 1;
        //ループは8秒ごとに行う。
        yield return new WaitForSeconds(8.0f);
        bombardActive = true;
    }
    //マップのサイズに応じて様々な物を落とす。
    private IEnumerator CreateFallingThing(int gridSizeX, int gridSizeZ)
    {
        int randomx;
        int randomz;
        bombardActive = false;
        for (int createThingCount = 0; createThingCount < fallingThingAmount;)
        {
            randomx = Random.Range(1, gridSizeX - 1);
            randomz = Random.Range(1, gridSizeZ - 1);
            int random = Random.Range(0,fallingThings.Count);
            transform.position = new Vector3(randomx, 7, randomz);
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit, 9);
            if ((hit.collider && hit.collider.tag == "Ground"))
            {
                GameObject fallingThing = Instantiate(fallingThings[random], transform.position, fallingThings[random].transform.rotation);
                fallingThing.transform.SetParent(bombardmentfallingthingHolder.transform);
                createThingCount++;
            }
            yield return new WaitForSeconds(5f);
        }
        fallingThingAmount += 1;
        yield return new WaitForSeconds(10.0f);
        bombardActive = true;
    }
    //全てのループを止める。
    public void StopRoof()
    {
        for (int i = 0; i < coroutines.Count; i++)
        {
            if (coroutines[i] != null)
            {

                StopCoroutine(coroutines[i]);
            }
        }

    }
}

