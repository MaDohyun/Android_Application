using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public float rotateSpeed;
 
    void Update()
    {//コインの回転
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
    
}
