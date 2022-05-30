using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour, IUseEquiptment
{
    public float cooltime;
    public float timer;
    public enum EquiptType { active, passive }
    public EquiptType equiptType;
    public Sprite equiptmentIcon;
    public string NAME;
    public string info;
    
    public virtual void UseEquiptment()
    {

    }
}