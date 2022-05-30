using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartyMemberChoiceController: MonoBehaviour
{
    public static int NumberOfPartyMembers = 3;
    
    
    public GameObject okbutton;
    public Text PartyCountText;
    // Start is called before the first frame update
    void Start()
    {
        okbutton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        PartyCountText.text = PartyMember.Party.Count+"/"+NumberOfPartyMembers;
        if(PartyMember.Party.Count== NumberOfPartyMembers)
        {
            okbutton.SetActive(true);
        }
        else if(PartyMember.Party.Count != NumberOfPartyMembers)
        {
            okbutton.SetActive(false);
        }
    }
}
