using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
// Start is called before the first frame update
{
    public virtual void AttackAction()
    {

    }
public virtual void DefenceAction()
    {

    }
public virtual void SkillAction()
    {

    }
public virtual void DamagedAction()
    {

    }
    public virtual void DeathAction()
    {

    }
    public virtual int getLife()
    {
        return 1;
    }
    public virtual int reducelife(int x)
    {
        return 1;
    }
    
    }
