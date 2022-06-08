using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//StartSceneのキャラクターを生成する時の効果のクラス
public class StartSceneSummonEffect : MonoBehaviour
{
    SpriteRenderer sr;
    float colorChange ;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        
        colorChange = 0;
        color = new Color(colorChange, colorChange, colorChange, colorChange);
        sr = this.GetComponent<SpriteRenderer>();
        sr.material.color = color;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (colorChange < 1)
        {
           
            color = new Color(colorChange, colorChange, colorChange, colorChange);
            colorChange += Time.deltaTime*0.2f;
        }
        if (colorChange < 1)
        {
            colorChange = 1;
            sr.material.color = color;
        }
    }
}
