using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRoundDestroy : MonoBehaviour
{
    static public bool leftfail ;
   void Start()
    {
        leftfail = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("LeftRound"))
        {
            MakeRound.leftRound.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            leftfail = true;
        }
    }

} 
