using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundLeftGoodDestroyer : MonoBehaviour
{
    public static bool leftdestroysuccess;
    private void Start()
    {
        leftdestroysuccess = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftRound"))
        {
            RoundController.combo += 1;
            Destroy(collision.gameObject);
            leftdestroysuccess = true;
            this.gameObject.SetActive(false);
        }
    }
}

