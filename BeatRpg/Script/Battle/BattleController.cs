using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    
    
    public GameObject player;
    public Enemy firstenemy;
    public Enemy secondenemy;
    public Enemy thirdenemy;
    //敵の登場スピード
    public float speed;
    public float bossspeed;
    //敵の登場位置
    public GameObject firstposition;
    public GameObject secondposition;
    public GameObject thirdposition;
    public GameObject Bossposition;
   
    void Update()
    {
        // 敵が3人以上の場合、配列の一番前の敵3匹にのみ指定された位置に移動させる。
        if (EnemyGenerator.EnemyList.Count > 3)
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

        // 敵が1の場合、ボスモンスターなので、ボスモンスターの指定された場所に移動させる。

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
        //PlayerController.keyは(1=攻撃,2=防御,3=行動しない)
        // 戦闘時にプレイヤーが攻撃を行い、一番前のモンスターが生きている場合、モンスターは攻撃を受ける行動を行う。

        if (PlayerController.key == 1 && EnemyGenerator.EnemyList[0].getLife() > 0)
        {
            firstenemy.DamagedAction();
        }
        // 戦闘時にプレイヤーがどのキーも押さない場合、一番前のモンスターが生きている場合、モンスターは攻撃の行動を行う。

        if (PlayerController.key == 3 && EnemyGenerator.EnemyList[0].getLife() > 0)
        {
           
            firstenemy.AttackAction();
            //RoundControllerの初期状態
            RoundController.state = 0;
        }
        // 戦闘時にプレイヤーが防御を行い、一番前のモンスターが生きている場合、モンスターは行動を行う。

        if (PlayerController.key == 2 && EnemyGenerator.EnemyList[0].getLife() > 0)
        {

            firstenemy.PlayerDefenceAction();
        }
       


    }


}
