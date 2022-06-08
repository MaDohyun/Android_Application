using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoundController : MonoBehaviour
{
    //タイミングに合わせて押すときに成功と判定されるボールの位置範囲
    private Vector2 min;
    private Vector2 max;
    //タイミングに合わせて押すときに成功判定
    bool left;
    bool right;
    private Collider2D leftcollider2Ds;
    private Collider2D rightcollider2Ds;
    //タイミングに合わせて押すときに成功判定アイコン
    public GameObject success;
    public GameObject fail;
    //タイミングに合わせて押すときに成功判定の状態(State=1の場合攻撃成功、2の場合防御成功、3の場合失敗)
    static public int state = 0;

    private void Start()

    {
        success.SetActive(false);
        fail.SetActive(false);
     
    }
    void Update()
    {
        if (EnemyGenerator.EnemyList.Count > 0 && PlayerController.life > 0)
        {
            //左の矢印のキーを押して攻撃する。
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                success.SetActive(true);
                Invoke("ResetResult", 0.2f);
                lefttiming();
                righttiming();
                if (left && right)
                {
                    state = 1;
                }
            }
            //キーを押した後リセットする。
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                state = 0;
                left = false;
                right = false;
            }
            //右の矢印のキーを押して攻撃する。
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                success.SetActive(true);
                Invoke("ResetResult",0.2f);
                lefttiming();
                righttiming();
                if (left && right)
                {
                    state = 2;
                }
            }
            //キーを押した後リセットする。
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                state = 0;
                left = false;
                right = false;
            }
            //キーを何も押さない時。
            if (RightRoundDestroy.rightfail && LeftRoundDestroy.leftfail)
            {
                fail.SetActive(true);
                Invoke("ResetResult", 0.2f);
                state = 3;
                RightRoundDestroy.rightfail = false;
                LeftRoundDestroy.leftfail = false;
            }
        }
    }
    //左の球をタイミングに合わせて押すときに成功判定
    void lefttiming()
    {
        for (int i = 0; i < MakeRound.leftRound.Count; i++)
        {

            if (
                0.1 <= MakeRound.leftRound[i].transform.localPosition.x &&
                MakeRound.leftRound[i].transform.localPosition.x <= 1.4
                )
            {
                Destroy(MakeRound.leftRound[i]);
                MakeRound.leftRound.RemoveAt(i);
                left = true;
                return;
            }
        }
    }
    //右の球をタイミングに合わせて押すときに成功判定
    void righttiming()
    {
        for (int i = 0; i < MakeRound.rightRound.Count; i++)
        {

            if (
                0.1 <= MakeRound.rightRound[i].transform.localPosition.x &&
                MakeRound.rightRound[i].transform.localPosition.x <= 1.4
                )
            {
                Destroy(MakeRound.rightRound[i]);
                MakeRound.rightRound.RemoveAt(i);
                right = true;
                return;
            }
        }
    }
    void ResetResult()
    {
        fail.SetActive(false);
        success.SetActive(false);
    }
}
