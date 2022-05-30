using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftRound"))
        {
            RoundController.combo = 0;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("RightRound"))
        {
            RoundController.combo = 0;
            Destroy(collision.gameObject);
        }
    }
}
