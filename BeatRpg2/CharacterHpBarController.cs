using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHpBarController : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    [SerializeField]
    private Character character;

    private float maxhp;
    private float curhp;


    // Start is called before the first frame update
    void Start()
    {
        character = character.GetComponent<Character>();
        maxhp = character.HP;
        curhp = character.HP;
        hpbar.value = (float)curhp / (float)maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        curhp = character.HP;
        
        HandleHP();

    }
    private void HandleHP()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, (float)curhp / (float)maxhp, Time.deltaTime * 10);
    }
}

