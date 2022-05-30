using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCrystal : Equipment
{
    [SerializeField] float damage;
    public GameObject lightning;
    int random;
    private void Start()
    {
        timer = cooltime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.playerState == Player.PlayerState.battle)
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if (Player.instance.playerState != Player.PlayerState.battle)
            {
                timer = cooltime;
            }
        if (timer <= 0)
        {
            UseEquiptment();
            timer = cooltime;
        }
    }

    public override void UseEquiptment()
    {
        for (int i = 0; i < 5; i++)
        {
            
            Invoke("MakeLightning", i * 0.3f);

        }

    }
    public void MakeLightning()
    {
        Vector2 targetVec;
        
        random = Random.Range(0, BattleManager.battleEnemyList.Count);
       
            targetVec = new Vector2(BattleManager.battleEnemyList[random].transform.position.x, lightning.transform.position.y);

            GameObject copy = Instantiate(lightning, targetVec, Quaternion.identity);
            copy.transform.SetParent(this.transform);
            BattleManager.battleEnemyList[random].TakeDamege(damage);
       
    }

   
}
