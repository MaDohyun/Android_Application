using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    Transform playerTransform;
    //カエラとプレイヤーの距離
    Vector3 cameraset;
    
    private void Awake()
    {
        playerTransform = player.transform;
        cameraset = transform.position - playerTransform.position;
    }
    //カメラはプレイヤーから一定距離を保ったままついて行く
    void LateUpdate()
    {
        transform.position = playerTransform.position + cameraset;
    }
}
