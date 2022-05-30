using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
   [SerializeField] EnemyDB enemyDB;
    int random;
    Enemy newEnemy;
   
    public Enemy GenerateLevel1Enemy()
    {
       random = Random.Range(0, enemyDB.Level1enemyList.Count);
                newEnemy = Instantiate(enemyDB.Level1enemyList[random]);
                newEnemy.transform.SetParent(this.transform);
         return newEnemy;
    }
    public Enemy GenerateLevel2Enemy()
    {
        random = Random.Range(0, enemyDB.Level2enemyList.Count);
        newEnemy = Instantiate(enemyDB.Level2enemyList[random]);
        newEnemy.transform.SetParent(this.transform);
        return newEnemy;
    }
    public Enemy GenerateLevel3Enemy()
    {
        random = Random.Range(0, enemyDB.Level3enemyList.Count);
        newEnemy = Instantiate(enemyDB.Level3enemyList[random]);
        newEnemy.transform.SetParent(this.transform);
        return newEnemy;
    }
    public Enemy GenerateBossEnemy1()
    {
        newEnemy = Instantiate(enemyDB.BossList[0]);
        newEnemy.transform.SetParent(this.transform);
        return newEnemy;
    }
    public Enemy GenerateBossEnemy2()
    {
        newEnemy = Instantiate(enemyDB.BossList[1]);
        newEnemy.transform.SetParent(this.transform);
        return newEnemy;
    }
    public Enemy GenerateBossEnemy3()
    {
        newEnemy = Instantiate(enemyDB.BossList[2]);
        newEnemy.transform.SetParent(this.transform);
        return newEnemy;
    }
    public Enemy GenerateBossEnemy4()
    {
        newEnemy = Instantiate(enemyDB.BossList[3]);
        newEnemy.transform.SetParent(this.transform);
        return newEnemy;
    }
}
