using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        if (EnemyGenerator.EnemyList.Count > 0)
        {
            EnemyGenerator.EnemyList = new List<EnemyController>();
        }
      

        if (MakeRound.leftRound.Count > 0)
        {
            MakeRound.leftRound = new List<GameObject>();
        }
        if (MakeRound.rightRound.Count > 0)
        {
            MakeRound.rightRound = new List<GameObject>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
