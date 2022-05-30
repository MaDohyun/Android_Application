using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : Enemy
{
   
    public override void Attack()
    {
        float playertakedamage;
        playertakedamage = targetShadow.HP;
        base.Attack();
        playertakedamage -= targetShadow.HP;
        CreateVampireText((int)playertakedamage);
       
        this.HP += playertakedamage;
    }

    public GameObject VampireText;
  
    public void CreateVampireText(int damage)
    {
        GameObject Text = Instantiate(VampireText);
        Text.transform.position = TextAppearTransform.position;
        Text.GetComponent<VampireText>().damage = damage;
        
    }
}
