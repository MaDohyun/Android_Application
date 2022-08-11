using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
     //プレイヤーの目的地
    public GameObject destination;
    //プレイヤーの動きスピード
    int moveSpeed;
    public GameObject map;
    //プレイヤーが移動した距離
    Vector2 mapGap;
    //プレイヤーが移動したx座標の距離
    float mapXGap;
    private void Update()
    {
        if (destination != null)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, destination.transform.position, Time.deltaTime * moveSpeed);
        }
        //プレイヤーが移動するとマップの移動させる。（カメラを動かせないため）
        map.transform.position = Vector2.MoveTowards(map.transform.position, mapGap, Time.deltaTime * moveSpeed);


    }
    //目的地をセットする
    public void SetDestination(GameObject destination,int Speed)
    {
        this.destination = destination;
        this.moveSpeed = Speed;
        mapXGap = destination.transform.position.x - this.gameObject.transform.position.x;
        mapGap = new Vector2(map.transform.position.x- mapXGap,map.transform.position.y);
    }


}
