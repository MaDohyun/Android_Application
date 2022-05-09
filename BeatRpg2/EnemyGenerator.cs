using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy slime;
    [SerializeField] private Enemy flyingeye;
    [SerializeField] private Enemy flyingeyeevent;
    [SerializeField] private Enemy skeleton;
    Enemy newenemy;
    public float monsterDelay;
    public float monstercooltime;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemy();
        Invoke("GenerateEnemy",0.5f);
        monsterDelay = 5;

    }

    // Update is called once per frame
    void Update()
    {
        if (monsterDelay >= 0)
        {
            monsterDelay -= Time.deltaTime;
        }
        else if(monsterDelay < 0){
            GenerateEnemy();
            monsterDelay = Random.Range(2,6);
        }

    }
    public void GenerateEnemy()
    {
        int a = Random.Range(1, 5);
        if (a == 1)
        {
            newenemy = Instantiate(slime);
            newenemy.transform.SetParent(this.transform);
            EnemyList.enemylist.Add(newenemy);
        }
        else if (a == 2)
        {
            newenemy = Instantiate(flyingeye);
            newenemy.transform.SetParent(this.transform);
            EnemyList.enemylist.Add(newenemy);
        }
        else if (a == 3)
        {
            newenemy = Instantiate(flyingeyeevent);
            newenemy.transform.SetParent(this.transform);
            EnemyList.enemylist.Add(newenemy);
        }
        else
        {
            newenemy = Instantiate(skeleton);
            newenemy.transform.SetParent(this.transform);
            EnemyList.enemylist.Add(newenemy);
        }


    }
}
