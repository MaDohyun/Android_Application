using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    Transform playerTransform;
    Vector3 cameraset;
    //uiㄴㅏ카메라는 이걸로 쓴다
    private void Awake()
    {
        playerTransform = player.transform;
        cameraset = transform.position - playerTransform.position;
    }
    void LateUpdate()
    {
        transform.position = playerTransform.position + cameraset;
    }
}
