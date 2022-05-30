using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShadow : MonoBehaviour
{
    [SerializeField] float FireBallSpeed;
    public float damage;

    private void Start()
    {
        Destroy(this.gameObject, 4.0f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * FireBallSpeed * Time.deltaTime;
    }

    public void SetFireBallDamage(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyPosition"))
        {
            collision.GetComponent<EnemyPosition>().TakeDamage(damage);

        }

    }
}
