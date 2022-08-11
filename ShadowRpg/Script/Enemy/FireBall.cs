using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //ファイアボールが飛ぶ速度
    [SerializeField] float FireBallSpeed;
    //ファイアボールダメージ
    public float damage;

    private void Start()
    {
        Destroy(this.gameObject,4.0f);
    }
    void Update()
    {
        //敵のファイアボールは左に動く
        transform.position += Vector3.left * FireBallSpeed * Time.deltaTime;
    }
    //ファイアボールダメージをセット
    public void SetFireBallDamage(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //"ShadowPosition"に当たるとダメージを与える。
        if (collision.CompareTag("ShadowPosition"))
        {
            collision.GetComponent<ShadowPosition>().TakeDamage(damage);
         
        }
        
    }
}
