using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject characterposition;
    [SerializeField]private int appearspeed;
    private bool positionok;

    // Start is called before the first frame update
    void Start()
    { 
        positionok = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterAppear();
    
    }

    public void CharacterAppear()
    {
        if (positionok == false && PartyMember.Party.Count>0)
        {
            for (int i = 0; i < PartyMember.Party.Count; i++)
            {
                PartyMember.Party[i].transform.position -= Vector3.left * appearspeed * Time.deltaTime;//(-1,0,0)

                if (PartyMember.Party[0].transform.position.x >= characterposition.transform.position.x)
                {
                    positionok = true;
                }
            }
        }
    }
}
