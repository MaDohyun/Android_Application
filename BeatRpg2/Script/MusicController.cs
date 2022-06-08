using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource theaudio;

    [SerializeField] private AudioClip[] clip;
    private int musiccount;

    public static string musiclevel;
    public static int selectedmusic;
    public static MusicController instance = null;

    // Start is called before the first frame update

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

    void Start()
    {
        theaudio = GetComponent<AudioSource>();
        musiccount = clip.Length;
    }

    public void PlayMusic(int i)
    {
        theaudio.clip = clip[i];
        theaudio.Play();
    }
    public int GetMusicCount()
    {
        return musiccount;
    }

    public void PlaySelectedMusic()
    {
        PlayMusic(selectedmusic);
    }

    public void StopMusic()
    {
        theaudio.Stop();
    }

}
