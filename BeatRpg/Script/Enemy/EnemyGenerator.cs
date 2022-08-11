using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    static public List<Enemy> EnemyList = new List<Enemy>();
    private int random;
    public Enemy enemy1;
    public Enemy enemy2;
    public Enemy enemy3;
    public Enemy boss;
    //モンスターの生成数
    public int createMonsterCounter;
    static public int monstercounter;
    // Start is called before the first frame update
    void Start()
    {

        monstercounter = createMonsterCounter;

        //モンスターをモンスターの生成数ほどランダムに生成する。
        for (int i = 0; i < monstercounter - 1; i++)
        {
            random = Random.Range(1, 100);
            if (random % 3 == 0)
            {
                Enemy newenemy = Instantiate(enemy1);
                EnemyList.Add(newenemy);
            }
            else if (random % 3 == 1)
            {
                Enemy newenemy = Instantiate(enemy2);
                EnemyList.Add(newenemy);
            }
            else if (random % 3 == 2)
            {
                Enemy newenemy = Instantiate(enemy3);
                EnemyList.Add(newenemy);
            }

        }
        //最後にボスモンスターを生成する。

        Enemy newboss = Instantiate(boss);
        EnemyList.Add(newboss);

    }

}
