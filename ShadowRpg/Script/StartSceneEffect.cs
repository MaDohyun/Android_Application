using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//StartSceneの演出のクラス
public class StartSceneEffect : MonoBehaviour
{
    public GameObject summonEffect1;
    public GameObject summonEffect2;
   
    private float EffectTime;

    float colorChange = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        EffectTime = 4;
        summonEffect1.GetComponent<SpriteRenderer>().color = new Color(colorChange, colorChange, colorChange, colorChange);
        summonEffect2.GetComponent<SpriteRenderer>().color = new Color(colorChange, colorChange, colorChange, colorChange);

    }

    // Update is called once per frame
    void Update()
    {
        if (EffectTime > 0)
        {
            EffectTime -= Time.deltaTime;
        }
        if(EffectTime <= 1.5)
        {
            if (colorChange < 1)
            {
                colorChange += Time.deltaTime * 0.3f;
                summonEffect1.SetActive(true);
                
                summonEffect1.GetComponent<SpriteRenderer>().color = new Color(colorChange, colorChange, colorChange, colorChange);
                summonEffect2.GetComponent<SpriteRenderer>().color = new Color(colorChange, colorChange, colorChange, colorChange);
            }
            if (colorChange >= 1)
            {
                colorChange = 1;
                
            }
        }
        if (EffectTime <= 0)
        {
            summonEffect2.SetActive(true);
        }


        }
}
