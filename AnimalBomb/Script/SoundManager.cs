using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    //backgroundを担当するAudio
    [SerializeField] private AudioSource backGroundAudio;
    //効果音を担当するAudio
    [SerializeField] private AudioSource effectAudio;
    //爆弾の音を担当するAudio
    [SerializeField] private AudioSource bombAudio;

    [Header("BackGroundMusic")]
    public AudioClip startSceneMusic;
    public AudioClip playSceneMusic;
    public AudioClip dangerMusic;

    [Header("Sound")]
    public AudioClip buttonSound;
    public AudioClip setBombSound;
    public AudioClip explodeBombSound;
    public AudioClip getItemSound;
    public AudioClip getCrownSound;

    public static SoundManager instance = null;

    [Header("Trigger")]
    bool startSceneMusicActive = false;
    bool playSceneMusicActive = false;
    bool dangerMusicActive = false;
    bool resultMusicActive = false;

    //シングルトンを用いる。
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
    }
   
    void Update()
    {
        //StartSceneの場合決まった音楽を流す
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            if (!startSceneMusicActive)
            {
                PlayStartSceneMusic();
            }
        }
        //PlaySceneの場合
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            //VSモードであれば時間の経過によって音楽を流す
            if (GameManager.instance.modeType == GameManager.ModeType.vs)
            {
                if (!playSceneMusicActive)
                {
                    PlayPlaySceneMusic();
                }
                if (playSceneMusicActive && GameManager.instance.mode.GetComponent<VSModeManager>().timeOuttimer <= 0 && !dangerMusicActive)
                {
                    PlayDangerMusic();
                }
            }
            //Survivalモードであれば決まった音楽を流す。
            else
            {
                if (!dangerMusicActive)
                {
                    PlayDangerMusic();
                }
            }
        }
        //ResultSceneの場合決まった音楽を流す
        if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            if (!resultMusicActive)
            {
                PlayResultSceneMusic();
            }
        }
    }
    //音楽を流すメソッド
    void PlayStartSceneMusic()
    {
        //Audioから流れていた音楽を止める。
        backGroundAudio.Stop();
        //clipを変える。
        backGroundAudio.clip = startSceneMusic;
        //clipをプレーさせる。
        backGroundAudio.Play();
            startSceneMusicActive = true;
    }
    void PlayPlaySceneMusic()
    {
        backGroundAudio.Stop();
        backGroundAudio.clip = playSceneMusic;
        backGroundAudio.Play();
        playSceneMusicActive = true;
    }
    void PlayDangerMusic()
    {
        backGroundAudio.Stop();
        backGroundAudio.clip = dangerMusic;
        backGroundAudio.Play();
        dangerMusicActive = true;
    }
    void PlayResultSceneMusic()
    {
        backGroundAudio.Stop();
        backGroundAudio.clip = startSceneMusic;
        backGroundAudio.Play();
        resultMusicActive = true;
    }
    public void PlayButtonSound()
    {
        effectAudio.clip = buttonSound;
        effectAudio.Play();
    }
    public void PlaySetBombSound()
    {
        effectAudio.clip = setBombSound;
        effectAudio.Play();
    }
    public void PlayGetItemSound()
    {
        effectAudio.clip = getItemSound;
        effectAudio.Play();
    }
    public void PlayGetCrownSound()
    {
        effectAudio.clip = getCrownSound;
        effectAudio.Play();
    }
    public void PlayExplodeBombSound()
    {
        bombAudio.clip = explodeBombSound;
        bombAudio.Play();
    }
   
}
