using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] float FireBallSpeed;
    public float damage;

    private void Start()
    {
        Destroy(this.gameObject,4.0f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * FireBallSpeed * Time.deltaTime;
    }

    public void SetFireBallDamage(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShadowPosition"))
        {
            collision.GetComponent<ShadowPosition>().TakeDamage(damage);
         
        }
        
    }
}
