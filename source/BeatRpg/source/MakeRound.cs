using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRound : MonoBehaviour
{
    static public List<GameObject> leftRound = new List<GameObject>();
    static public List<GameObject> rightRound = new List<GameObject>();
    public List<GameObject> rr;
    public GameObject leftround;
    public GameObject rightround;
    public float lefttimeSpeed;
    public float righttimeSpeed;
    float lefttimer = 0;
    float righttimer = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
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
        rr = leftRound;
        

    }

}
