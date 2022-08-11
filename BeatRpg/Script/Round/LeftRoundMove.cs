using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRoundMove : MonoBehaviour
{
    //左の球のスピード
    public float LeftRoundspeed;
  
    void Update()
    {
        //左の球の動き
        transform.position += Vector3.right * LeftRoundspeed * Time.deltaTime;//(-1,0,0)
        
    }
}
