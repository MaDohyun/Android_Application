using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//敵のHpを用いたゲージバー
public class ShadowHpBarController : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    [SerializeField]
    private Shadow shadow;

    private float maxhp;
    private float curhp;


    // Start is called before the first frame update
    void Start()
    {
        shadow = shadow.GetComponent<Shadow>();
        maxhp = shadow.HP;
        curhp = shadow.HP;
        hpbar.value = (float)curhp / (float)maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        curhp = shadow.HP;
        
        HandleHP();

    }
    private void HandleHP()
    {//線形補間を用いて柔らかなゲージバーを実装
        hpbar.value = Mathf.Lerp(hpbar.value, (float)curhp / (float)maxhp, Time.deltaTime * 10);
    }
}

