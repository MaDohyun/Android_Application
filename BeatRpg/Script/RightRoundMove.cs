using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRoundMove : MonoBehaviour
{
    //右の球のスピード
    public float RightRoundSpeed;
    void Update()
    {
        //右の球の動き
        transform.position += Vector3.left * RightRoundSpeed * Time.deltaTime;//(-1,0,0)

    }
}
