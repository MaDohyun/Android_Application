using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 //AI、CPUのクラス
 //CPUはセンサーを持っていてセンサーがCPUの周りの場所について調べてからCPUは行動する。
public class CPU : MonoBehaviour
{
    Animator anim;
    //CPUのキャラクターオブジェクト
    [Header("Model")]
    public GameObject cpuModelObject;

    [Header("Prefab")]
    public GameObject bombPrefab;

    [Header("Status")]
    public float cpuSpeed = 2.5f;
    public int cpuExplosionPower { get; set; } = 2;
    public int cpuExplosionAmount { get; set; } = 1;
    public int cpuMaxExplosionPower = 11;
    public int cpuMaxExplosionAmount = 7;
    public float cpuMaxSpeed = 4.0f;

    [Header("Vectors")]
    //空いてる方向
    public List<Vector3> emptyMoveVectorList;
    //安全な方向
    public List<Vector3> safeMoveVectorList;
    //ボームから反対方向
    public List<Vector3> runMoveVectorList;
    //目的地の方向
    public Vector3 destination;
    //現時点の方向
    public Vector3 currentDirection;

    [Header("Item")]
    public Equiptment_Meat meat = null;
    public Equiptment_Scroll scroll = null;
    public Equiptment_AutoBomb autoBomb = null;

    [Header("LayerMasks")]
    public LayerMask bombLayer;

    //目的地に行けない場合、他の目的地を調べ始めるためのタイマー
    float moveTimer = 0;
    //設置したボームのリスト
    public List<GameObject> setBomsList;
    //CPUのセンサー
    public GameObject sensorObject;
    CPU_Secsor cPU_Secsor;

    [Header("Trigger")]
    public bool canAction = true;
    int random;

    void Start()
    {
        cPU_Secsor = sensorObject.GetComponent<CPU_Secsor>();
        anim = cpuModelObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         //CPUは決まっている能力値を超えることはできない。
        if (cpuExplosionPower > cpuMaxExplosionPower)
        {
            cpuExplosionPower = cpuMaxExplosionPower;
        }
        if (cpuSpeed > cpuMaxSpeed)
        {
            cpuSpeed = cpuMaxSpeed;
        }
        if (cpuExplosionAmount > cpuMaxExplosionAmount)
        {
            cpuExplosionAmount = cpuMaxExplosionAmount;
        }
        //次の行動を決める。
        DecideAction();
        //meatアイテムがあれば使う。
        if (meat)
        {
            meat.UseItem();
        }
    }
    //次の行動を決める。
    void DecideAction()
    {
        if (canAction)
        {
            canAction = false;
            //周りの空いてる場所を調べる。
            DetectEmptyPlace();
            //空いてる場所の安全性を調べる。
            DetectSafePlace();
            //ボームからの判定方向に逃げる場所を調べる。
            DetectRunPlace();
            //破壊できるブロックにあった場合
            MeetDestructableWall();
            //プレイヤーにあった場合
            MeetPlayer();
            //CPUにあった場合
            MeetCPU();
            //移動する目的地を決める。
            DecideMove();
        }
        //動きを始める。
        StartCoroutine(Move());
    }
    //周りの空いてる方向を調べる。
    private void DetectEmptyPlace()
    {
        //空いてる方向のリストの初期化
        emptyMoveVectorList.RemoveRange(0, emptyMoveVectorList.Count);
        //センサーは周りの方向に何があるか判別する。
        //空いてるか、プレイヤーがいるか、CPUがいるか、アイテムがある場合は空いてると判定する。
        if (cPU_Secsor.DetectObstacle(Vector3.forward, 1) == CPU_Secsor.ObstacleType.empty ||
           cPU_Secsor.DetectObstacle(Vector3.forward, 1) == CPU_Secsor.ObstacleType.player ||
           cPU_Secsor.DetectObstacle(Vector3.forward, 1) == CPU_Secsor.ObstacleType.cpu ||
           cPU_Secsor.DetectObstacle(Vector3.forward, 1) == CPU_Secsor.ObstacleType.item)
        {
            emptyMoveVectorList.Add(Vector3.forward);
        }
        if (cPU_Secsor.DetectObstacle(Vector3.back, 1) == CPU_Secsor.ObstacleType.empty ||
           cPU_Secsor.DetectObstacle(Vector3.back, 1) == CPU_Secsor.ObstacleType.player ||
           cPU_Secsor.DetectObstacle(Vector3.back, 1) == CPU_Secsor.ObstacleType.cpu ||
           cPU_Secsor.DetectObstacle(Vector3.back, 1) == CPU_Secsor.ObstacleType.item)
        {
            emptyMoveVectorList.Add(Vector3.back);
        }
        if (cPU_Secsor.DetectObstacle(Vector3.left, 1) == CPU_Secsor.ObstacleType.empty ||
           cPU_Secsor.DetectObstacle(Vector3.left, 1) == CPU_Secsor.ObstacleType.player ||
           cPU_Secsor.DetectObstacle(Vector3.left, 1) == CPU_Secsor.ObstacleType.cpu ||
           cPU_Secsor.DetectObstacle(Vector3.left, 1) == CPU_Secsor.ObstacleType.item)
        {
            emptyMoveVectorList.Add(Vector3.left);
        }
        if (cPU_Secsor.DetectObstacle(Vector3.right, 1) == CPU_Secsor.ObstacleType.empty ||
           cPU_Secsor.DetectObstacle(Vector3.right, 1) == CPU_Secsor.ObstacleType.player ||
           cPU_Secsor.DetectObstacle(Vector3.right, 1) == CPU_Secsor.ObstacleType.cpu ||
           cPU_Secsor.DetectObstacle(Vector3.right, 1) == CPU_Secsor.ObstacleType.item)
        {
            emptyMoveVectorList.Add(Vector3.right);
        }
    }
    //空いてる方向の安全性を調べる。
    private void DetectSafePlace()
    {
        //安全な方向のリストを初期化する。
        safeMoveVectorList.RemoveRange(0, safeMoveVectorList.Count);
        //空いてる方向のリストに対して危ない場所かどうか判別し、危なくないなら安全な方向のリストに登録する。
        if (emptyMoveVectorList.Count > 0)
        {
            for (int i = 0; i < emptyMoveVectorList.Count; i++)
            {
                if (!DetectDangerPlace(emptyMoveVectorList[i]))
                {
                    safeMoveVectorList.Add(emptyMoveVectorList[i]);
                }
            }
        }
        if (!DetectDangerPlace(Vector3.zero))
        {
            safeMoveVectorList.Add(Vector3.zero);
        }
    }
    //方向に対して危ない場所かどうか判別する
    private bool DetectDangerPlace(Vector3 direction)
    {
        //センサーをその場に送って、ボームを認識しなければ危なくないと判別する。
        sensorObject.transform.position = gameObject.transform.position + direction;
        if (!sensorObject.GetComponent<CPU_Secsor>().DetectBomb(Vector3.forward)
               && !sensorObject.GetComponent<CPU_Secsor>().DetectBomb(Vector3.back)
               && !sensorObject.GetComponent<CPU_Secsor>().DetectBomb(Vector3.left)
               && !sensorObject.GetComponent<CPU_Secsor>().DetectBomb(Vector3.right)
                && !sensorObject.GetComponent<CPU_Secsor>().DetectBomb(Vector3.zero)
              )
        {
            //センサーの位置の初期化
            sensorObject.transform.position = gameObject.transform.position;
            return false;
        }
        else
        {
            sensorObject.transform.position = gameObject.transform.position;
            return true;
        }
    }
    //ボームの方向を調べてその反対方向を逃げる方向にする。
    private void DetectRunPlace()
    {
        runMoveVectorList.RemoveRange(0, runMoveVectorList.Count);
        for (int i = 0; i < cPU_Secsor.DetectBombDirection().Count; i++)
        {
            for (int j = 0; j < emptyMoveVectorList.Count; j++)
            {
                ////ボームの方向を調べて空いてるならその反対方向を逃げる方向にする。
                if (-1 * cPU_Secsor.DetectBombDirection()[i] == emptyMoveVectorList[j])
                {
                    runMoveVectorList.Add(emptyMoveVectorList[j]);
                }
            }
        }
    }
    //破壊できるブロックにあった場合
    private void MeetDestructableWall()
    {

        if (cPU_Secsor.DetectObstacle(Vector3.forward, 1) != CPU_Secsor.ObstacleType.destructablewall
                && cPU_Secsor.DetectObstacle(Vector3.back, 1) != CPU_Secsor.ObstacleType.destructablewall
                && cPU_Secsor.DetectObstacle(Vector3.left, 1) != CPU_Secsor.ObstacleType.destructablewall
                && cPU_Secsor.DetectObstacle(Vector3.right, 1) != CPU_Secsor.ObstacleType.destructablewall)
        {
        }
        else
        {
            //安全な場所が二つ以上あって自分が危なくない場合し設置したボームが自分のボーム量より少ない場合ボームを設置する。
            if (safeMoveVectorList.Count > 1 && setBomsList.Count < cpuExplosionAmount)
            {
                CPUDropBomb();
            }
        }
    }
    //プレイヤーにあった場合
    private void MeetPlayer()
    {
        //爆弾威力内にプレイヤーがいるか調べる。
        if (cPU_Secsor.DetectObstacle(Vector3.forward, cpuExplosionPower - 1) != CPU_Secsor.ObstacleType.player
                && cPU_Secsor.DetectObstacle(Vector3.back, cpuExplosionPower - 1) != CPU_Secsor.ObstacleType.player
                && cPU_Secsor.DetectObstacle(Vector3.left, cpuExplosionPower - 1) != CPU_Secsor.ObstacleType.player
                && cPU_Secsor.DetectObstacle(Vector3.right, cpuExplosionPower - 1) != CPU_Secsor.ObstacleType.player)
        {
        }
        else
        {
            if (!meat)
            {  //安全な場所が二つ以上あって自分が危なくない場合し設置したボームが自分のボーム量より少ない場合ボームを設置する。
                if (safeMoveVectorList.Count > 1 && setBomsList.Count < cpuExplosionAmount)
                {
                    CPUDropBomb();
                }
            }
            //meatアイテムがある場合
            else if (meat)
            {
                //安全な場所が二つ以上あって自分が危なくない場合し設置したボームが自分のボーム量より少ない場合ボームを設置する。
                if (safeMoveVectorList.Count > 1 && setBomsList.Count < cpuExplosionAmount)
                {
                    CPUDropBomb();
                    //設置したボームの中に一番最近のボームを動けるように設定する。
                    setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().canMove = true;
                    //プレイヤーの方向にボームを動かせる。
                    if (cPU_Secsor.DetectObstacle(Vector3.forward, cpuExplosionPower - 1) == CPU_Secsor.ObstacleType.player)
                    {
                        setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().Move(Vector3.forward);
                    }
                    else if (cPU_Secsor.DetectObstacle(Vector3.back, cpuExplosionPower - 1) == CPU_Secsor.ObstacleType.player)
                    {
                        setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().Move(Vector3.back);
                    }
                    else if (cPU_Secsor.DetectObstacle(Vector3.left, cpuExplosionPower - 1) == CPU_Secsor.ObstacleType.player)
                    {
                        setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().Move(Vector3.left);
                    }
                    else if (cPU_Secsor.DetectObstacle(Vector3.right, cpuExplosionPower - 1) == CPU_Secsor.ObstacleType.player)
                    {
                        setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().Move(Vector3.right);
                    }
                }
            }
        }
    }
    //CPUにあった場合
    //プレイヤーにあった場合と同じな動きをする。
    private void MeetCPU()
    {
        if (cPU_Secsor.DetectObstacle(Vector3.forward, cpuExplosionPower - 1) != CPU_Secsor.ObstacleType.cpu
                && cPU_Secsor.DetectObstacle(Vector3.back, cpuExplosionPower - 1) != CPU_Secsor.ObstacleType.cpu
                && cPU_Secsor.DetectObstacle(Vector3.left, cpuExplosionPower - 1) != CPU_Secsor.ObstacleType.cpu
                && cPU_Secsor.DetectObstacle(Vector3.right, cpuExplosionPower - 1) != CPU_Secsor.ObstacleType.cpu)
        {
        }
        else
        {
            if (!meat)
            {
                if (safeMoveVectorList.Count > 1 && setBomsList.Count < cpuExplosionAmount)
                {
                    CPUDropBomb();
                }
            }
            else if (meat)
            {
                if (safeMoveVectorList.Count > 1 && setBomsList.Count < cpuExplosionAmount)
                {
                    CPUDropBomb();
                    setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().canMove = true;
                    if (cPU_Secsor.DetectObstacle(Vector3.forward, cpuExplosionPower - 1) == CPU_Secsor.ObstacleType.cpu)
                    {
                        setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().Move(Vector3.forward);
                    }
                    else if (cPU_Secsor.DetectObstacle(Vector3.back, cpuExplosionPower - 1) == CPU_Secsor.ObstacleType.cpu)
                    {
                        setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().Move(Vector3.back);
                    }
                    else if (cPU_Secsor.DetectObstacle(Vector3.left, cpuExplosionPower - 1) == CPU_Secsor.ObstacleType.cpu)
                    {
                        setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().Move(Vector3.left);
                    }
                    else if (cPU_Secsor.DetectObstacle(Vector3.right, cpuExplosionPower - 1) == CPU_Secsor.ObstacleType.cpu)
                    {
                        setBomsList[setBomsList.Count - 1].GetComponent<Bomb>().Move(Vector3.right);
                    }
                }
            }
        }
    }
    //ボームを作る。
    private void CPUDropBomb()
    {
        if (autoBomb)
        {
            autoBomb.UseItem();
        }
        else
        {
            if (bombPrefab)
            {
                //ボームを位置に生成する。
                var pos = new Vector3(Mathf.RoundToInt(transform.position.x), bombPrefab.transform.position.y,
                    Mathf.RoundToInt(transform.position.z));
                GameObject bomb = Instantiate(bombPrefab, pos, bombPrefab.transform.rotation);
                //ボームを設定する。
                bomb.GetComponent<Bomb>().explosionPower = cpuExplosionPower;
                bomb.GetComponent<Bomb>().maker = gameObject;
                //設置ボームリストに作ったボームを登録する。
                setBomsList.Add(bomb);
                canAction = true;
            }
        }
    }
    //動きを決める。
    void DecideMove()
    {
        //安全な方向がある場合
        if (safeMoveVectorList.Count > 0)
        {
            for (int i = 0; i < safeMoveVectorList.Count; i++)
            {
                //安全な方向の中にアイテムがあればそこに向かう。
                if (sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(safeMoveVectorList[i], 1) == CPU_Secsor.ObstacleType.item)
                {
                    destination = transform.position + safeMoveVectorList[i];
                    ChangeRotation(safeMoveVectorList[i]);
                    return;
                }
            }
            //アイテムがない場合はランダムな安全な方向に向かう。
            random = Random.Range(0, safeMoveVectorList.Count);
            destination = transform.position + safeMoveVectorList[random];
            ChangeRotation(safeMoveVectorList[random]);
        }
        //安全な方向がない場合
        else
        {
            //空いてる方向がある場合
            if (emptyMoveVectorList.Count > 0)
            {
                for (int i = 0; i < emptyMoveVectorList.Count; i++)
                {
                    //空いてる方向の周りをセンサーで検索して隔てられた所かどうか判別する。
                    sensorObject.transform.position = gameObject.transform.position + emptyMoveVectorList[i];
                    if (sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(Vector3.forward, 1) == CPU_Secsor.ObstacleType.empty ||
                        sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(Vector3.back, 1) == CPU_Secsor.ObstacleType.empty ||
                        sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(Vector3.left, 1) == CPU_Secsor.ObstacleType.empty ||
                        sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(Vector3.right, 1) == CPU_Secsor.ObstacleType.empty)
                    {
                        ////空いてる方向の周りに空いてる場所があればそこに向かう。
                        destination = transform.position + emptyMoveVectorList[i];
                        ChangeRotation(emptyMoveVectorList[i]);
                        sensorObject.transform.position = gameObject.transform.position;
                        return;
                    }
                }
                //センサーを戻す。
                sensorObject.transform.position = gameObject.transform.position;
                //ボームから反対方向があればそこに向かう。
                if (runMoveVectorList.Count > 0)
                {
                    random = Random.Range(0, runMoveVectorList.Count);
                    destination = transform.position + runMoveVectorList[random];
                    ChangeRotation(runMoveVectorList[random]);
                }
                //ランダムな空いてる方向に向かう。
                else
                {
                    random = Random.Range(0, emptyMoveVectorList.Count);
                    destination = transform.position + emptyMoveVectorList[random];
                    ChangeRotation(emptyMoveVectorList[random]);
                }
            }
            //空いてる方向がない場合
            else
            {
                //meatアイテムを持っていればmeatアイテムを使ってボームを投げて空いてる場所を作る。
                if (meat)
                {
                    if (sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(Vector3.forward, 1) == CPU_Secsor.ObstacleType.bomb)
                    {
                        destination = transform.position + Vector3.forward;
                    }
                    if (sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(Vector3.left, 1) == CPU_Secsor.ObstacleType.bomb)
                    {
                        destination = transform.position + Vector3.left;
                    }
                    if (sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(Vector3.right, 1) == CPU_Secsor.ObstacleType.bomb)
                    {
                        destination = transform.position + Vector3.right;
                    }
                    if (sensorObject.GetComponent<CPU_Secsor>().DetectObstacle(Vector3.back, 1) == CPU_Secsor.ObstacleType.bomb)
                    {
                        destination = transform.position + Vector3.back;
                    }
                }
            }
        }
    }
    //動くためのコルーチン
    private IEnumerator Move()
    {
        //目的地と距離が0.1以上であるば動く。
        if (Vector3.Distance(destination, transform.position) >= 0.1f)
        {
            moveTimer += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * cpuSpeed);
            anim.SetBool("isMove", true);
            //目的地に1秒が経っても届かない場合はまた新しく行動する。
            if (moveTimer > 1.0f)
            {
                moveTimer = 0;
                canAction = true;
            }
        }
        else
        {
            moveTimer = 0;
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            canAction = true;
        }
        //目的地が今の場所であれば動くアニメを止める。
        if (destination == Vector3.zero)
        {
            anim.SetBool("isMoving", false);
        }
        yield return null;
    }
    //方向に合わせて回転する。
    void ChangeRotation(Vector3 direction)
    {
        currentDirection = direction;
        if (direction.z > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (direction.z < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }
    
       public void OnTriggerEnter(Collider other)
    {
        //爆発に当たるとオブジェクトを削除する。
        if (other.CompareTag("Explosion"))
        {
            //設置したボームリストから自分を消す
            for(int i= setBomsList.Count-1; i>=0 ; i--)
            {
                setBomsList[i].GetComponent<Bomb>().maker = null;
            }
            //センサーを破壊する。
            Destroy(sensorObject);
            //GameManagerのリストから自分を消す
            for (int i=0;i< GameManager.instance.CPUs.Count; i++)
            {
                if(GameManager.instance.CPUs[i] == this.gameObject)
                {
                    GameManager.instance.CPUs.RemoveAt(i) ;
                }
            }
            Destroy(this.gameObject);
        }
    }



}
