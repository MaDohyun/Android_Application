using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour
{
    public GameObject selectline;
    public GameObject gameob;
    public bool regist;
    private int partynumber;
    private GameObject instance;
    void Start()
    {
        selectline.SetActive(false);
        regist = false;

    }
    public void CharacterRegister()
    {
        if (regist == false)
        {
            if (PartyMember.Party.Count < PartyMemberChoiceController.NumberOfPartyMembers)
            {
                selectline.SetActive(true);
                regist = true;
                instance = Instantiate(gameob);
                PartyMember.Party.Add(instance);
            }
            else
            {
                Debug.Log("cant");
            }
        }
        else if (regist == true)
        {
            partynumber = PartyMember.Party.IndexOf(instance);
            selectline.SetActive(false);
            regist = false;
            Destroy(instance);
            PartyMember.Party.RemoveAt(partynumber);
        }
         

        }
    
}
    
