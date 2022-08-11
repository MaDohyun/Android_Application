using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このクラスを持っていると重力を受けるようにy軸の値が小さくなってある程度の値になると止める。
public class FallingThing : MonoBehaviour
{
    [Header("Trigger")]
    bool fallingActive = false;
    void Update()
    {
        if (!fallingActive)
        {
            transform.position += Vector3.down*Time.deltaTime*5;
            if(transform.position.y < 0.5)
            {
                fallingActive = true;
            }
        }
    }
}
