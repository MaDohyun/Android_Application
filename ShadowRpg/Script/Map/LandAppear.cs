using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//マップでlandを活性化させるコライダーオブジェクトのクラス
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
        //最初は全てのlandを無効化させる。
        LandOff();

    }
    //このコライダーオブジェクトはプレイヤーと一定の距離を持ってついて行く
    void LateUpdate()
    {
        LandOn();
            transform.position = playerTransform.position + NextLandOnset;
    }
    //プレイヤーとlandとの距離が2500より小さい時landを活性化させる。
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
