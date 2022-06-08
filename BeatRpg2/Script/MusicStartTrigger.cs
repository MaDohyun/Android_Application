using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStartTrigger : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RightRound") || collision.CompareTag("LeftRound"))
        {
            MusicController.instance.PlaySelectedMusic();
           
            this.gameObject.SetActive(false);
        }
    }
}
