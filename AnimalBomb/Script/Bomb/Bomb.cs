using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [Header("Particle")]
    public GameObject explosionPrefab;

    [Header("Model")]
    public GameObject bombModelObject;

    [Header("LayerMasks")]
    public LayerMask wallLayer;
    public LayerMask destructablewallLayer;
    public LayerMask characterLayer;

    [Header("Trigger")]
    //動きをするかどうか
    public bool moveActive = false;
    //動ける状況かどうか
    public bool canMove = false;
    //爆発したかどうか
    private bool exploded = false;

    //動く目的地
    Transform destination;
    //動く方向
    Vector3 moveDirection;
    
    //爆弾の威力
    public int explosionPower { get; set; } = 1;
    //爆弾を生成したオブジェクト
    public GameObject maker { get; set; }
    //爆弾が爆発までかかる時間
    public float explosionTime { get; set; } = 3.0f;
    void Start()
    {
        //爆弾はexplosionTimeの時間後爆発する。
        Invoke("Explode", explosionTime);
    }
    private void Update()
    {
        //動きをする
        if (moveActive)
        {
            //ターゲットを探す
            if (DetectTarget(moveDirection))
            {
                //目的地はターゲットの位置になる。
                destination = DetectTarget(moveDirection).transform;
            }
            //目的地がある場合は動くコルーチンを始める。
            if (destination)
            {
                StartCoroutine(MoveDestination(moveDirection));
            }
        }
    }
    //爆発メソッド
    private void Explode()
    {
        //爆発particleを生成する。
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //爆発が行っているさい、爆発の姿を消す
        bombModelObject.SetActive(false);
        //コルーチンを通じた連鎖爆発
        StartCoroutine(CreateExplosions(Vector3.forward)); // 위로 펼치는 
        StartCoroutine(CreateExplosions(Vector3.right)); // 오른쪽으로 펼치는 
        StartCoroutine(CreateExplosions(Vector3.back)); // 아래로 펼치기 
        StartCoroutine(CreateExplosions(Vector3.left));
        //爆発が行った後trueにする。
        exploded = true;
        //爆発するさいのサウンドを流す。
        SoundManager.instance.PlayExplodeBombSound();
        //爆弾のオブジェクトは0.2f後破壊される。それは連鎖爆発が終わるまでの時間を持つ必要があるからである。
        Invoke("Destroythis", 0.2f);
    }
    //爆弾のオブジェクトを消す。
    void Destroythis()
    {
        //爆弾を作ったオブジェクトが存在する場合
        if (maker != null)
        {
            //爆弾を作ったオブジェクトがCPUの場合
            if (maker.GetComponent<CPU>() != null)
            {
                //CPUの爆弾リストから自分を消す。
                for (int i = 0; i < maker.GetComponent<CPU>().setBomsList.Count; i++)
                {
                    if (maker.GetComponent<CPU>().setBomsList[i] = this.gameObject)
                    {
                        maker.GetComponent<CPU>().setBomsList.RemoveAt(i);
                    }
                }
            }
            //爆弾を作ったオブジェクトがPlayerの場合
            else if (maker.GetComponent<Player>() != null)
            {
                //Playerの爆弾リストから自分を消す。
                for (int i = 0; i < maker.GetComponent<Player>().setBomsList.Count; i++)
                {
                    if (maker.GetComponent<Player>().setBomsList[i] = this.gameObject)
                    {
                        maker.GetComponent<Player>().setBomsList.RemoveAt(i);
                    }
                }
            }
        }
        //自分のオブジェクトを消す。
        Destroy(gameObject);
    }
    //方向に応じて連鎖爆発させるコルーチン関数
    private IEnumerator CreateExplosions(Vector3 direction)
    {
        // 爆弾の威力ほどループする   
        for (int i = 1; i < explosionPower; i++)
        {
            // ブロックとのヒット判定結果を保存する変数
            RaycastHit wallHit;
            RaycastHit destructablewallHit;
            RaycastHit characterHit;
            // 方向にブロックやキャラクターがあるか確認する
            Physics.Raycast
            (
                transform.position + new Vector3(0, 0f, 0),
                direction,
                out wallHit,
                i,
                wallLayer
            );
            Physics.Raycast
           (
               transform.position + new Vector3(0, 0f, 0),
               direction,
               out destructablewallHit,
               i,
               destructablewallLayer
           );
            Physics.Raycast
           (
               transform.position + new Vector3(0, 0f, 0),
               direction,
               out characterHit,
               i,
               characterLayer
           );

            // 方向にブロックやキャラクターがない場合
            if (!wallHit.collider&& !destructablewallHit.collider &&!characterHit.collider)
            {
                //またparticleを入力された方向に生成して連鎖爆発を続ける
                GameObject explosion = Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
                explosion.transform.parent = transform;
            }
            // 方向に破壊できるブロックがある場合
            else if (destructablewallHit.collider)
            {
                //particleを一回だけ入力された方向に生成してループを止める。
                //これは破壊できるブロックがparticleを感知して破壊されるため一回だけparticleを生成する必要がある。
                GameObject explosion = Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
                explosion.transform.parent = transform;
                break;
            }
            // 方向にキャラクターがいる場合
            else if (characterHit.collider)
            {
                //particleを一回だけ入力された方向に生成してループを止める。
                //これはキャラクターがparticleを感知してなくなるため一回だけparticleを生成する必要がある。
                GameObject explosion = Instantiate
                (
                    explosionPrefab,
                    transform.position + (i * direction),
                    explosionPrefab.transform.rotation
                );
                explosion.transform.parent = transform;
                break;
            }

            // 方向にブロックがある場合
            else
            {
                //ループを止めて爆発を中断させる。
                break;
            }
            //まだループが続いている場合0.001秒後にまたループを続く。
            yield return new WaitForSeconds(0.001f);
        }
    }
    //動くメソッド
    public void Move(Vector3 direction)
    {
        if (canMove)
        {
            moveActive = true;
            moveDirection = direction;
        }
    }

    public IEnumerator MoveDestination(Vector3 direction)
    {
        //目的地と1f以上距離がある場合、目的地にむいて動く
        if (Vector3.Distance(destination.position, transform.position) >= 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(destination.position.x, transform.position.y, destination.position.z), Time.deltaTime * 8);
        }
        //目的地と距離が近い場合、動きを止める。
        else
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            moveActive = false;
        }
        yield return null;
    }
    //方向に物があるかどうか確認する。
    public GameObject DetectTarget(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast
        (
            transform.position + new Vector3(0, 0, 0), direction, out hit, 1
        );

        if (hit.collider)
        {
            return null;
        }
        else
        {
            Physics.Raycast
            (
                transform.position + new Vector3(0, 0, 0), direction, out hit, GameManager.instance.gridSizeX - 3
            );
            if (hit.collider)
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }
    public void OnTriggerEnter(Collider other)
    {
        //Explosion(爆発particle)と触れる場合はすぐ爆発する。
        if (!exploded && other.CompareTag("Explosion"))
        {
            // 2 重に爆発処理が実行されないようにすでに爆発処理が実行されている場合は止める
            CancelInvoke("Explode");
            // 爆発する
            Explode();
        }
    }
    //爆弾を生成した後にコライダーが衝突しないようにisTrigger　= tureに設定する。
    private void OnTriggerStay(Collider other)
    {
        if (!exploded && other.CompareTag("CPU"))
        {
            GetComponent<Collider>().isTrigger = true;
        }
        if (!exploded && other.CompareTag("Player"))
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }
    //CPUやPlayerが離れるとコライダーがが衝突できるようにisTrigger　= falseに設定する。
    private void OnTriggerExit(Collider other)
    {
        if (!exploded && other.CompareTag("CPU"))
        {
            GetComponent<Collider>().isTrigger = false;
            canMove = true;
        }
        if (!exploded && other.CompareTag("Player"))
        {
            GetComponent<Collider>().isTrigger = false;
            canMove = true;
        }
    }
    
}
