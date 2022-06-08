using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//プレイヤーから一定距離離れているlandのボタンを活性化させるコライダーオブジェクトのクラス
public class NextLandOnSwitch : MonoBehaviour
{
    [SerializeField]   GameObject player;
    
    Transform playerTransform;
    Vector3 NextLandOnset;
    
    private void Awake()
    {
        playerTransform = player.transform;
        NextLandOnset = transform.position - playerTransform.position;
    }
    //このコライダーオブジェクトはプレイヤーと一定の距離を持ってついて行く
    void LateUpdate()
    {
        transform.position = playerTransform.position + NextLandOnset;
    }
    //Landに当たるとlandOnをtrueにしてボタンを活性化させる。
    private void OnTriggerStay2D(Collider2D collision)
    {
            if (collision.CompareTag("Land"))
            {
            
                collision.gameObject.GetComponent<Land>().landOn = true;

        }

    }
    //Landから離れるとlandOnをfalseにしてボタンを無効化させる。
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Land"))
        {

            collision.gameObject.GetComponent<Land>().landOn = false;

        }

    }
}
