using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillArrow : MonoBehaviour
{
    
    public float damage;
    public int ArrowSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         transform.position += Vector3.right * ArrowSpeed * Time.deltaTime;
       
        ArrowHit();
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
