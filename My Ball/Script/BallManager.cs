using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallManager : MonoBehaviour
{
    //ジャンプする力
    public float jumpPower;
    public GameManager gameManager;
    //獲得したコインの数
    public int coinCount;
    //ジャンプ中であるか判断
    bool isJump;
   
    //ステージの始まりの場所
    public Vector3 stage3position;
    public Vector3 stage4position;
    //プレイヤーの位置
    public Vector3 playerposition;
    Rigidbody rigid;
  
    public AudioSource CoinAudioSource;
    public AudioSource JumpAudioSource;
    public AudioSource RedAudioSource;
    public AudioSource GoalAudioSource;
    public AudioClip CoinSoundClip;
    public AudioClip JumpSoundClip;
    public AudioClip RedSoundClip;
    public AudioClip GoalSoundClip;

    void Awake()
    {
       
        isJump = false;
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {　
        playerposition = this.gameObject.transform.position;
        //ジャンプキーは基本SpaceボタンであるためInput.GetButtonDown("Jump")
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            //AddForceを通じてY軸に力をいれる。
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            JumpAudioSource.PlayOneShot(JumpSoundClip);
        }
    }
    //物理の処理はFixedUpdateで行う。
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    //地面に当たるときジャンプの状態をOffする。
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        //コインに当たる時
        if (other.tag == "Coin")
        {
            coinCount++;
            CoinAudioSource.PlayOneShot(CoinSoundClip);
            other.gameObject.SetActive(false);
        }
        //"stage2clear"場所に当たる時
        if (other.tag == "stage2clear")
        {
            gameManager.stageClearNumber = 2;
        }
        //ステージ3の赤い地面に当たる時、プレイヤーはステージの始まりの場所に戻る。
        if (other.tag == "redtrigger" && gameManager.stageClearNumber == 2)
        {
            RedAudioSource.PlayOneShot(RedSoundClip);
            this.gameObject.transform.position = stage3position;
        }
        //ステージ4の赤い地面に当たる時、プレイヤーはステージの始まりの場所に戻る。
        if (other.tag == "redtrigger" && gameManager.stageClearNumber == 3)
        {
            RedAudioSource.PlayOneShot(RedSoundClip);
            this.gameObject.transform.position = stage4position;
        }
        //"stage3clear"場所に当たる時
        if (other.tag == "stage3clear")
        {
            GoalAudioSource.PlayOneShot(GoalSoundClip);
            gameManager.stageClearNumber = 3;
        }
        //"Goal"場所に当たる時コインの数が足りないとプレイヤーはステージの始まりの場所に戻る。
        if (other.tag == "Goal" && coinCount < gameManager.TotalCoinCount)
        {
            this.transform.position = stage4position;
            
        }
        //"Goal"場所に当たる時コインの数が足りたらクリア
        else if (other.tag == "Goal" && coinCount >= gameManager.TotalCoinCount)
        {
            gameManager.stageClearNumber = 4;
            
        }

    }
    public void resetcoinCount()
    {
        coinCount = 0;
    }
   
}