using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRoundDestroy : MonoBehaviour
{
    //右の球をの失敗
    static public bool rightfail;
    void Start()
    {
        rightfail = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //右の球が当たると破壊する。
        if (collision.CompareTag("RightRound"))
        {
            MakeRound.rightRound.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            rightfail = true;
        }
    }
}
