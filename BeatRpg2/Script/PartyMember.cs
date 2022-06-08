using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : MonoBehaviour
{
    public GameObject player;
    public static List<GameObject> Party = new List<GameObject>();
    // Start is called before the first frame update

    
    void Start()
    {
        PartyMember.Party.Add(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
