using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
    public GameObject destination;
    int moveSpeed;
    public GameObject map;
    Vector2 mapGap;
    float mapXGap;
    private void Update()
    {
        if (destination != null)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, destination.transform.position, Time.deltaTime * moveSpeed);
        }
        map.transform.position = Vector2.MoveTowards(map.transform.position, mapGap, Time.deltaTime * moveSpeed);


    }
    
    public void SetDestination(GameObject destination,int Speed)
    {
        this.destination = destination;
        this.moveSpeed = Speed;
        mapXGap = destination.transform.position.x - this.gameObject.transform.position.x;
        mapGap = new Vector2(map.transform.position.x- mapXGap,map.transform.position.y);
    }


}
