using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAppear : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Land[] lands;
    [SerializeField] Transform landHolder;

    Transform playerTransform;
    Vector3 NextLandOnset;

    private void Awake()
    {
        playerTransform = player.transform;
        NextLandOnset = transform.position - playerTransform.position;
        lands = landHolder.GetComponentsInChildren<Land>();
        LandOff();

    }
    private void Start()
    {
        
    }

    void LateUpdate()
    {
        LandOn();
            transform.position = playerTransform.position + NextLandOnset;
    }
    public void LandOn()
    {for (int i = 0; i < lands.Length; i++) {
            if (Mathf.Abs(player.transform.position.x - lands[i].gameObject.transform.position.x) < 2500)
            {
                lands[i].gameObject.SetActive(true);
            }
        }
    }
    public void LandOff()
    {
        for (int i = 0; i < lands.Length; i++)
        {
                lands[i].gameObject.SetActive(false);
           
        }
    }
}
