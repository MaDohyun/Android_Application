using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

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

    public int Money;
    public List<Shadow> haveShadowList;
    public List<Equipment> haveEquipmentList;
    public List<Shadow> battleShadowList ;
    public List<Equipment> battleEquipmentList;
    
    void Start()
    {
       
    }

    
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
