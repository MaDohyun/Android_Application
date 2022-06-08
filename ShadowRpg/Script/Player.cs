using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // シングルトーンパターンを利用
    public static Player instance = null;
    //プレイヤーがバトル中なのかどうか
    public enum PlayerState {battle,notbattle }
    public PlayerState playerState;
    // Start is called before the first frame update
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
  


    }
    //プレイヤーのお金
    public int Money;
    //プレイヤーが持っているキャラクター
    public List<Shadow> haveShadowList;
    //プレイヤーが持っている装備
    public List<Equipment> haveEquipmentList;
    //プレイヤーが持っているキャラクターの中にバトルに参加するキャラクター
    public List<Shadow> battleShadowList ;
    //プレイヤーが持っている装備の中にバトルに参加する装備
    public List<Equipment> battleEquipmentList;
    
    void Update()
    {
        if(BattleManager.battleEnemyList.Count > 0)
        {
            playerState = PlayerState.battle;
        }
        if (BattleManager.battleEnemyList.Count == 0)
        {
            playerState = PlayerState.notbattle;
        }

    }
}
