using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShadow : MonoBehaviour
{　　　//ファイアボールが飛ぶ速度
    [SerializeField] float FireBallSpeed;
    //ファイアボールダメージ
    public float damage;

    private void Start()
    {
        Destroy(this.gameObject, 4.0f);
    }
    
    void Update()
    {
        //キャラクターのファイアボールは右に動く
        transform.position += Vector3.right * FireBallSpeed * Time.deltaTime;
    }
    //ファイアボールダメージをセット
    public void SetFireBallDamage(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //"ShadowPosition"に当たるとダメージを与える。
        if (collision.CompareTag("EnemyPosition"))
        {
            collision.GetComponent<EnemyPosition>().TakeDamage(damage);

        }

    }
}
