using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤークラス
public class Player : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    [Header("Model")]
    public GameObject playerModelObject;

    [Header("Status")]
    public float playerSpeed = 2.5f;
    public float playerMaxSpeed = 4.0f;
    public int playerExplosionPower { get; set; } = 2;
    public int playerExplosionAmount { get; set; } = 1;
    public int playerMaxExplosionPower = 11;
    public int playerMaxExplosionAmount = 7;

    [Header("Trigger")]
    public bool canDropBombs = true;

    [Header("Prefab")]
    public GameObject bombPrefab;

    [Header("List")]
    public List<GameObject> setBomsList;

    [Header("ItemObject")]
    public Equiptment_Meat meat = null;
    public Equiptment_Scroll scroll = null;
    public Equiptment_AutoBomb autoBomb = null;

    [Header("Layer")]
    public LayerMask bombLayer;

    //プレイヤーの移動値
    float xMove;
    float zMove;
    public Vector3 currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        anim = playerModelObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //プレイヤーは決まっている能力値を超えることはできない。
        if (playerExplosionPower > playerMaxExplosionPower)
        {
            playerExplosionPower = playerMaxExplosionPower;
        }
        if (playerExplosionAmount > playerMaxExplosionAmount)
        {
            playerExplosionAmount = playerMaxExplosionAmount;
        }
        if (playerSpeed > playerMaxSpeed)
        {
            playerSpeed = playerMaxSpeed;
        }
        //プレイヤーの動き
        PlayerMove();
        //プレイヤー爆弾生成
        PlayerDropBomb();
        //meatアイテムがある場合
        if (meat)
        {
            meat.UseItem();
        }
    }
    //プレイヤーの動き
    private void PlayerMove()
    {
        anim.SetBool("isMove", false);
        //プレイヤーはキーボードの入力値によって自由に動ける。
        //キーボードの入力値をxMove,zMoveに保存する。
        xMove = Input.GetAxisRaw("Horizontal");
        zMove = Input.GetAxisRaw("Vertical");
        //zMoveが0より大きい場合上にむいているする。
        if (zMove > 0)
        {
            //方向に合わせて回転する。
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //現時点の方向を設定する。
            currentDirection = Vector3.forward;
            anim.SetBool("isMove", true);
        }
        //zMoveが0より小さい場合下にむいているする。
        if (zMove < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            currentDirection = Vector3.back;
            anim.SetBool("isMove", true);
        }
        //xMoveが0より大きい場合右にむいているする。
        if (xMove > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            currentDirection = Vector3.right;
            anim.SetBool("isMove", true);
        }
        //xMoveが0より小さい場合左にむいているする。
        if (xMove < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            currentDirection = Vector3.left;
            anim.SetBool("isMove", true);
        }
        //velocityを利用してプレイヤーを動かす
        rb.velocity = new Vector3(xMove * playerSpeed, rb.velocity.y, zMove * playerSpeed);
    }
    //プレイヤーがスペイスきーを押すと爆弾を生成する。
    private void PlayerDropBomb()
    {
        //ボームを作ることができる状況で、設置しているボームが設置できるボームより少ないとボームを生成する。
        if (canDropBombs && Input.GetKeyDown(KeyCode.Space) && setBomsList.Count < playerExplosionAmount)
        {
            //autoBombのアイテムがある場合そのアイテムを使う。
            if (autoBomb)
            {
                autoBomb.UseItem();
            }
            else
            {
                if (bombPrefab)
                {
                    var pos = new Vector3
                    (Mathf.RoundToInt(transform.position.x), bombPrefab.transform.position.y, Mathf.RoundToInt(transform.position.z));
                    GameObject bomb = Instantiate(bombPrefab, pos, bombPrefab.transform.rotation);
                    bomb.GetComponent<Bomb>().explosionPower = playerExplosionPower;
                    bomb.GetComponent<Bomb>().maker = gameObject;
                    setBomsList.Add(bomb);
                    SoundManager.instance.PlaySetBombSound();
                }
            }
        }
    }
        public void OnTriggerEnter(Collider other)
    {
        //ボームを作った直後はボームをまた作れない状況になる。
        if (canDropBombs && other.CompareTag("Bomb"))
        {
            canDropBombs = false;
        }
        // プレイヤーは爆発に触れるとなくなる
        if (other.CompareTag("Explosion"))
        {
            for (int i = setBomsList.Count - 1; i >= 0; i--)
            {
                //爆弾の製作者を設定する。
                setBomsList[i].GetComponent<Bomb>().maker = null;
            }
            GameManager.instance.player = null;
            Destroy(this.gameObject);
        }
    }
    //作ったボームから離れるとまたボームを作れるようになる。
        public void OnTriggerExit(Collider other)
    {
        if (!canDropBombs && other.CompareTag("Bomb"))
        {
            canDropBombs = true;
        }
    }
   
}
