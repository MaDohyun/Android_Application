using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このクラスを持っているオブジェクトは8秒後に破壊される。
//Survivalモードで利用されている。
public class Destroy8second : MonoBehaviour
{
    float time = 8;
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) {
            Destroy(this.gameObject);
        }
    }
}
