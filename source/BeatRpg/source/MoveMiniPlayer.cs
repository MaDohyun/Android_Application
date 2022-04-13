using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMiniPlayer : MonoBehaviour
{
    private Vector2 vec;
    public int firstmonsternumber;
    public int lastmonsternumber;
    private Vector2 vec2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        firstmonsternumber = EnemyGenerator.firstmonsternumber;
        lastmonsternumber = EnemyGenerator.EnemyList.Count;
        vec2.Set(3 + 3.9f -
            (3.9f * lastmonsternumber / firstmonsternumber), 4.26f);
        transform.position = vec2;
    }
    
}
