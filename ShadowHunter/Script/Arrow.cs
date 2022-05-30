using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    public bool right;
    public float damage;
    public int ArrowSpeed = 5;
    public Hunter hunter;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
         
        if (right)
        {
            transform.position += Vector3.right * ArrowSpeed * Time.deltaTime;
        }
        else if (right != true)
        {
            transform.position += Vector3.left * ArrowSpeed * Time.deltaTime;
        }
        ArrowHit();
    }
    
    public void SetArrow(bool r,float d)
    {
        right = r;
        damage = d;
    }
    public Transform boxpos;
    public Vector2 boxSize;

    public void ArrowHit()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(boxpos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Enemy")
            {
                collider.gameObject.GetComponent<Enemy>().TakeDamege(damage);
                Destroy(this.gameObject);
            }
            
        }
    }
}
