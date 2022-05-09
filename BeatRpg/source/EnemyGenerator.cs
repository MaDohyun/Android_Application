using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    static public List<EnemyController> EnemyList = new List<EnemyController>();
    private int random;
    public EnemyController enemy1;
    public EnemyController enemy2;
    public EnemyController enemy3;
    public EnemyController boss;
    public int monsternumber;
    static public int firstmonsternumber;
    // Start is called before the first frame update
    void Start()
    {
        
        firstmonsternumber = monsternumber;

        for (int i = 0; i < monsternumber-1; i++)
        {
            random = Random.Range(1, 100);
            if (random % 3 == 0)
            {
                EnemyController newenemy = Instantiate(enemy1);
                EnemyList.Add(newenemy);
            }
            else if (random % 3 == 1)
            {
                EnemyController newenemy = Instantiate(enemy2);
                EnemyList.Add(newenemy);
            }
            else if (random % 3 == 2)
            {
                EnemyController newenemy = Instantiate(enemy3);
                EnemyList.Add(newenemy);
            }

        }
        EnemyController newboss = Instantiate(boss);
        EnemyList.Add(newboss);

        Debug.Log(EnemyGenerator.EnemyList.Count);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
}
