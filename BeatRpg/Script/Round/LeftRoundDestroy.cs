using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRoundDestroy : MonoBehaviour
{
    //左の球をの失敗
    static public bool leftfail ;
   void Start()
    {
        leftfail = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //左の球が当たると破壊する。
        if (collision.CompareTag("LeftRound"))
        {
            MakeRound.leftRound.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            leftfail = true;
        }
    }

} 
