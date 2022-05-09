using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRegister : MonoBehaviour
{
    public GameObject easyselectline;
    public GameObject normalselectline;
    public GameObject hardselectline;
    
    // Start is called before the first frame update
    void Start()
    {
        easyselectline.SetActive(true);
        normalselectline.SetActive(false);
        hardselectline.SetActive(false);

    }

    public void EasyLevelRegist()
    {
            normalselectline.SetActive(false);
            hardselectline.SetActive(false);
            easyselectline.SetActive(true);
        MusicController.musiclevel = "Easy";
    }
    public void NormalLevelRegist()
    {
       
            easyselectline.SetActive(false);
            hardselectline.SetActive(false);
            normalselectline.SetActive(true);
        MusicController.musiclevel = "Normal";
       
    }
    public void HardLevelRegist()
    {
       
            normalselectline.SetActive(false);
            easyselectline.SetActive(false);
            hardselectline.SetActive(true);
        MusicController.musiclevel = "Hard";
        
    }
}
