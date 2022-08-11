using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRound : MonoBehaviour
{
    //左の球の配列
    static public List<GameObject> leftRound = new List<GameObject>();
    //右の球の配列
    static public List<GameObject> rightRound = new List<GameObject>();
    
    public GameObject leftround;
    public GameObject rightround;
    //左の球が生成するスピード
    public float lefttimeSpeed;
    //右の球が生成するスピード
    public float righttimeSpeed;
    float lefttimer = 0;
    float righttimer = 0;
   
    void Update()
    {
        lefttimer += Time.deltaTime;
        righttimer += Time.deltaTime;
        if (lefttimer > lefttimeSpeed)
        {
            GameObject newleftround = Instantiate(leftround);
            leftRound.Add(newleftround);
            newleftround.transform.position = new Vector3(-7.5f, -5.0f, 0);
            lefttimer = 0;
        }
        if (righttimer > righttimeSpeed)
        {
            GameObject newrightround = Instantiate(rightround);
            rightRound.Add(newrightround);
            newrightround.transform.position = new Vector3(9.0f, -5.0f, 0);
            righttimer = 0;
        }
       
    }

}
