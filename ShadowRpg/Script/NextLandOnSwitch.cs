using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLandOnSwitch : MonoBehaviour
{
    [SerializeField]   GameObject player;
    
    Transform playerTransform;
    Vector3 NextLandOnset;
    
    private void Awake()
    {
        playerTransform = player.transform;
        NextLandOnset = transform.position - playerTransform.position;
    }
    void LateUpdate()
    {
        transform.position = playerTransform.position + NextLandOnset;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
            if (collision.CompareTag("Land"))
            {
            
                collision.gameObject.GetComponent<Land>().landOn = true;

        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Land"))
        {

            collision.gameObject.GetComponent<Land>().landOn = false;

        }

    }
}
