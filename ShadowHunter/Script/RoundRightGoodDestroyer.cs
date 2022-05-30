using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundRightGoodDestroyer : MonoBehaviour
{
    public static bool rightdestroysuccess;
    private void Start()
    {
        rightdestroysuccess = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RightRound"))
        {
            RoundController.combo += 1;
            Destroy(collision.gameObject);
            rightdestroysuccess = true;
            this.gameObject.SetActive(false);
        }
    }
}
