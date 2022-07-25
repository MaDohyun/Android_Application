using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    //SoundManager内のボタンの音を流す。
    public void PlayButtonSound()
    {
        SoundManager.instance.PlayButtonSound();
    }
}
