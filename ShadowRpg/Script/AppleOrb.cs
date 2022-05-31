using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleOrb : Equipment
{
    public GameObject heal;
    float healtimer = 0;
    [SerializeField] float healVolume;
    private void Start()
    {
        timer = cooltime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healtimer > 0)
        {
            healtimer -= Time.deltaTime;
            for(int i = 0; i< Player.instance.battleShadowList.Count; i++)
            {
                Player.instance.battleShadowList[i].HP += Time.deltaTime* healVolume;
            }
        }
       
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
        Instantiate(heal);
        healtimer = 5.0f;
        
    }
    
}
