using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    
    
    public GameObject player;
    public EnemyController firstenemy;
    public EnemyController secondenemy;
    public EnemyController thirdenemy;
    public float speed;
    public float bossspeed;
    public GameObject firstposition;
    public GameObject secondposition;
    public GameObject thirdposition;
    public GameObject Bossposition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {  if (EnemyGenerator.EnemyList.Count > 3)
        {
            firstenemy = EnemyGenerator.EnemyList[0];
            firstenemy.transform.position = Vector3.MoveTowards(firstenemy.transform.position,
                firstposition.transform.position, speed * Time.deltaTime);
            secondenemy = EnemyGenerator.EnemyList[1];
            secondenemy.transform.position = Vector3.MoveTowards(secondenemy.transform.position,
                secondposition.transform.position, speed * Time.deltaTime);
            thirdenemy = EnemyGenerator.EnemyList[2];
            thirdenemy.transform.position = Vector3.MoveTowards(thirdenemy.transform.position,
                thirdposition.transform.position, speed * Time.deltaTime);
        }
        if (EnemyGenerator.EnemyList.Count == 3)
        {
            firstenemy = EnemyGenerator.EnemyList[0];
            firstenemy.transform.position = Vector3.MoveTowards(firstenemy.transform.position,
                firstposition.transform.position, speed * Time.deltaTime);
            secondenemy = EnemyGenerator.EnemyList[1];
            secondenemy.transform.position = Vector3.MoveTowards(secondenemy.transform.position,
                secondposition.transform.position, speed * Time.deltaTime);
            thirdenemy = EnemyGenerator.EnemyList[2];
            
        }
        if (EnemyGenerator.EnemyList.Count == 2)
        {
            firstenemy = EnemyGenerator.EnemyList[0];
            
            firstenemy.transform.position = Vector3.MoveTowards(firstenemy.transform.position,
                firstposition.transform.position, speed * Time.deltaTime);
            secondenemy = EnemyGenerator.EnemyList[1];
            
        }
        if (EnemyGenerator.EnemyList.Count == 1)
        {
            firstenemy = EnemyGenerator.EnemyList[0];
            firstenemy.transform.position = Vector3.MoveTowards(firstenemy.transform.position,
                Bossposition.transform.position, bossspeed * Time.deltaTime);

        }
        if (EnemyGenerator.EnemyList.Count > 0)
        {
            Battle();
        }
    }
    void Battle()
    {
       
        if (PlayerController.key == 1 && EnemyGenerator.EnemyList[0].getLife() > 0)
        {
            firstenemy.DamagedAction();
        }
        if (PlayerController.key == 3 && EnemyGenerator.EnemyList[0].getLife() > 0)
        {
           
            firstenemy.AttackAction();
            RoundController.state = 0;
        }
        if (PlayerController.key == 2 && EnemyGenerator.EnemyList[0].getLife() > 0)
        {

            firstenemy.DefenceAction();
        }
       


    }


}
