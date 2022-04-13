using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRoundDestroy : MonoBehaviour
{
    static public bool rightfail;
    void Start()
    {
        rightfail = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RightRound"))
        {
            MakeRound.rightRound.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            rightfail = true;
        }
    }
}
