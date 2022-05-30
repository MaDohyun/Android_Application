using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    [SerializeField] private int scenenumber;
    [SerializeField] private bool resetcharacter;
    [SerializeField] private bool stopmusic;
    private void Start()
    {

    }
    public void nextScene()
    { if (resetcharacter == false) {
            for (int i = 0; i < PartyMember.Party.Count; i++)
            {
                DontDestroyOnLoad(PartyMember.Party[i].gameObject);
            }
        }
        else if (resetcharacter)
        {
            for (int i = 0; i < PartyMember.Party.Count; i++)
            {
                Destroy(PartyMember.Party[i].gameObject);
            }
        }
        
        if (stopmusic)
        {
            MusicController.instance.StopMusic();
        }
        SceneManager.LoadScene(scenenumber);
    }
   

}