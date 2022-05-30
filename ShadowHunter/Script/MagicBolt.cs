using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBolt : MonoBehaviour
{
     Enemy target;
    Vector3 targetVec;
    
    int random;


    bool isTarget;
    public int moveSpeed;
    public float damage;
    private void Start()
    {
        isTarget = false;
        if (BattleManager.battleEnemyList.Count > 0)
        {
            random = Random.Range(0, BattleManager.battleEnemyList.Count);
            target = BattleManager.battleEnemyList[random];
            targetVec = target.transform.position;
        }
    }
    private void Update()
    {

        if (!isTarget)
        {
           this.transform.position =  Vector3.MoveTowards(gameObject.transform.position, targetVec, Time.deltaTime * moveSpeed);
            if (Mathf.Abs(Vector3.Distance(transform.position,targetVec)) < 0.1f)
            {
                isTarget = true;
            }

        }
        if (isTarget)
        {
            if (target != null)
            {
                target.TakeDamege(damage);
            }
            Destroy(this.gameObject);
        }
    }
    }
