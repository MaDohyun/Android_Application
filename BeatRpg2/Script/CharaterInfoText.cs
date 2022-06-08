using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CharaterInfoText : MonoBehaviour, IPointerEnterHandler
{
    public Character character;
    public Text nametext;
    public Text infotext;
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        nametext.text = character.NAME;
        infotext.text = "Damage:" + character.DAMAGE + "\n" + "Hp:" + character.HP + "\n" +
            "Deffence:" + character.DEFFENCE + "\n" + "Skill:"  + character.SKILL +"\n"+
            character.SKILLINFO;
    }
}
