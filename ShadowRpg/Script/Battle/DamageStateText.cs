using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//ダメージを受けるときのtextクラス
public class DamageStateText : MonoBehaviour
{
  
    private float moveSpeed;
    private float alphaSpeed;
    private float destroyTime;
    TextMeshPro text;
    Color alpha;
    public int damage;
    public string state;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2.0f;
        //透明になるスピード
        alphaSpeed = 2.0f;
        destroyTime = 2.0f;

        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        //ダメージが０の場合状態を表す。
        if (damage == 0)
        {
            text.text =  state;
        }
        else
        {
            text.text = damage.ToString();
        }
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        //線形補間を利用してどんどん透明になるようにする。
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); 
        text.color = alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
    