using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChoiceController : MonoBehaviour
{
    [SerializeField] private MusicController musicController;
    [SerializeField] private Sprite[] musicimage;
    public Image image;

    
    public Text musicinfo;
   
    // Start is called before the first frame update
    void Start()
    {
        image.GetComponent<Image>();
        MusicController.selectedmusic = 0;
        MusicController.musiclevel = "Easy";
        musicController.PlayMusic(MusicController.selectedmusic);
        image.sprite = musicimage[MusicController.selectedmusic];
    }

    private void Update()
    {
        if(MusicController.selectedmusic == 0){
            musicinfo.text = "Music効果:" + "\n" + "仲間のHpが10%Up!";  
        }
        else if (MusicController.selectedmusic == 1)
        {
            musicinfo.text = "Music効果:" + "\n" + "仲間の攻撃力が5%Up!";
        }
        else if (MusicController.selectedmusic == 2)
        {
            musicinfo.text = "Music効果:" + "\n" + "仲間の防御力が50%Up!";
        }
        else if (MusicController.selectedmusic == 3)
        {
            musicinfo.text = "Music効果:" + "\n" + "仲間の攻撃Speedが30%Up!";
        }
    }
    public void LeftSelectButton()
    {
        if (MusicController.selectedmusic >0)
        {
            MusicController.selectedmusic -= 1;
            musicController.PlayMusic(MusicController.selectedmusic);
            image.sprite = musicimage[MusicController.selectedmusic];
        }
        else
        {
            MusicController.selectedmusic = musicController.GetMusicCount() - 1;
            musicController.PlayMusic(MusicController.selectedmusic);
            image.sprite = musicimage[MusicController.selectedmusic];
        }
    }
    public void RightSelectButton()
    {
        if (MusicController.selectedmusic < musicController.GetMusicCount()-1)
        {
            MusicController.selectedmusic += 1;
            musicController.PlayMusic(MusicController.selectedmusic);
            image.sprite = musicimage[MusicController.selectedmusic];
        }
        else
        {
            MusicController.selectedmusic = 0;
            musicController.PlayMusic(MusicController.selectedmusic);
            image.sprite = musicimage[MusicController.selectedmusic];
        }
    }

}
