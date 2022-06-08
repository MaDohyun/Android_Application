using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{

    public override void Attack()
    {
        if (closeenemy != null && Vector2.Distance(this.transform.position, closeenemy.transform.position) <= RANGE)
        {
            closeenemy.GetComponent<Enemy>().TakeDamege(DAMAGE);
        }
          
    }



}
