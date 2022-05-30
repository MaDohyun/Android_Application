using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : Equipment
{
    [SerializeField] float damage;
    [SerializeField] int moveSpeed;
    public GameObject magicBolt;
    private void Start()
    {
        timer = cooltime;
        magicBolt.GetComponent<MagicBolt>().damage = damage;
        magicBolt.GetComponent<MagicBolt>().moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {if(Player.instance.playerState == Player.PlayerState.battle)
        if (timer >0)
        {
            timer -= Time.deltaTime;
        }
    else if(Player.instance.playerState != Player.PlayerState.battle)
        {
            timer = cooltime;
        }
     if(timer <= 0)
        {
            UseEquiptment();
            timer = cooltime;
        }
    }

    public override void UseEquiptment()
    {
        GameObject copy = Instantiate(magicBolt,this.transform.position ,Quaternion.identity);
        copy.transform.SetParent(this.transform);
    }
}
