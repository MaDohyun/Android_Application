using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Character
{
    public GameObject Arrow;
    public Transform trans;
    private Vector2 vec = new Vector2(0,3.0f);
    public override void Attack()
    {
        Arrow.GetComponent<Arrow>().SetArrow(right,DAMAGE);
        Instantiate(Arrow,trans);
    }
}
