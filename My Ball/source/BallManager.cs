using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallManager : MonoBehaviour
{
    public float jumpPower;
    public GameManager gameManager;
    public int coinCount;
    bool isJump;
    public int stageclear;
    public Vector3 stage3position;
    public Vector3 stage4position;
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
    {//ㅈㅓㅁㅍㅡㄴㅡㄴ ㄱㅣㅂㅗㄴㅇㅣ ㅅㅡㅍㅔㅇㅣㅅㅡ
        playerposition = this.gameObject.transform.position;
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            JumpAudioSource.PlayOneShot(JumpSoundClip);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coinCount++;
            CoinAudioSource.PlayOneShot(CoinSoundClip);
            other.gameObject.SetActive(false);
        }
        
        if (other.tag == "stage2clear")
        { 
            stageclear = 2;
        }
        if (other.tag == "redtrigger" && stageclear == 2)
        {
            RedAudioSource.PlayOneShot(RedSoundClip);
            this.gameObject.transform.position = stage3position;
        }
        if (other.tag == "redtrigger" && stageclear == 3)
        {
            RedAudioSource.PlayOneShot(RedSoundClip);
            this.gameObject.transform.position = stage4position;
        }
        if (other.tag == "stage3Goal")
        {
            GoalAudioSource.PlayOneShot(GoalSoundClip);
            stageclear = 3;
        }
        if (other.tag == "Goal")
        {
            stageclear = 4;
        }
        if (gameManager.gettranscubetrigger() == false)
        {
            transform.position += Vector3.up * Time.deltaTime * 5;

        }
        
        if (gameManager.gettranscubetrigger())
        {
            transform.position += Vector3.down * Time.deltaTime * 5;

        }
    }
    public void resetcoinCount()
    {
        coinCount = 0;
    }
    public void notclearstage4()
    {
        stageclear = 3;
    }
}