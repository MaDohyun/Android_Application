using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : Enemy
{
    // Start is called before the first frame update
    void Awake()
    {
        EnemyList.enemylist[0] = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
