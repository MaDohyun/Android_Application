using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoundController : MonoBehaviour
{
    private Vector2 min;
    private Vector2 max;
    bool left;
    bool right;
    private Collider2D leftcollider2Ds;
    private Collider2D rightcollider2Ds;
    public GameObject success;
    public GameObject fail;
    static public int state = 0;

    private void Start()

    {

        success.SetActive(false);
        fail.SetActive(false);
        // min = new Vector2(scope.localPosition.x - scope.rect.width/2,
        //   scope.localPosition.x + scope.rect.width/2);
        // max = new Vector2(scope.localPosition.y - scope.rect.height / 2,
        //   scope.localPosition.y + scope.rect.height / 2);


    }
    void Update()
    {
        if (EnemyGenerator.EnemyList.Count > 0 && PlayerController.life > 0)
        {
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
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                state = 0;
                left = false;
                right = false;
            }
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
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                state = 0;
                left = false;
                right = false;
            }
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
