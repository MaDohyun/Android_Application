using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//自動的に敵に追いつくオートボンブクラス
public class AutoBomb : MonoBehaviour
{
    Animator anim;

    [Header("Model")]
    public GameObject autoBombModelObject;

    //オートボンブの目的地
    public Vector3 destination;
    //行動できるかどうかループをしすぎるのを防ぐために存在
    public bool canAction = false;
    //オートボンブのスピード
    public float autoBombSpeed = 0.8f;
    //一番近くにある敵
    GameObject closeTarget;
    //敵のリスト
    public List<GameObject> targets;
    void Start()
    {
        anim = autoBombModelObject.GetComponent<Animator>();
        
    }
    private void Update()
    {
        DecideAction();
        if (canAction)
        {
            StartCoroutine(Move());
        }
    }
    //次の行動を決める。
    void DecideAction()
    {
        //一番近い敵を決める。
        DetectCloseTarget();
        //方向に合わせて回転する。
        ChangeRotation();
        //一番近い敵があれば目的地を決める。
        if (closeTarget)
        {
            destination = new Vector3(closeTarget.transform.position.x, transform.position.y, closeTarget.transform.position.z);
            canAction = true;
        }
        else
        {
            canAction = false;
        }
    }
    private IEnumerator Move()
    {
        //目的地から距離が0.1以上の場合は目的地にむいて移動する。
        if (Vector3.Distance(destination, transform.position) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * autoBombSpeed);
            anim.SetBool("isMove", true);
        }
        else
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            anim.SetBool("isMove", false);
        }
        //ループを一回ずつするための設定
        canAction = false;
        yield return null;
    }
    //一番近い敵を探す
    public GameObject DetectCloseTarget()
    {
        
        SetTargets();
        closeTarget = null;
        if(targets.Count > 0)
        {
            closeTarget = targets[0];
        }
            for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] && closeTarget)
            {
                if (Vector3.Distance(targets[i].transform.position, transform.position)
                    < Vector3.Distance(closeTarget.transform.position, transform.position))
                {
                    closeTarget = targets[i];
                }
            }
        }
        return closeTarget;
    }
    //初期敵のリストを設定する。
    void SetTargets()
    {
       //敵のリストを初期化する。
        if (targets.Count > 0)
        {
            targets.RemoveRange(0, targets.Count - 1);
        }
        //GameManagerのPlayerやCPUオブジェクトが自分ではない場合敵リストに追加する。
        if (GameManager.instance.player)
        {
            if (GameManager.instance.player != this.gameObject.GetComponent<Bomb>().maker)
            {
                targets.Add(GameManager.instance.player);
            }
        }
        for (int i = 0; i < GameManager.instance.CPUs.Count; i++)
        {
            if (GameManager.instance.CPUs[i] != this.gameObject.GetComponent<Bomb>().maker)
            {
                targets.Add(GameManager.instance.CPUs[i]);
            }
        }
    }
    //方向に合わせて回転する。
    void ChangeRotation()
    {
        if (closeTarget)
        {
            if (closeTarget.transform.position.x > this.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (closeTarget.transform.position.x < this.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            //回転しすぎておかしく見えるのを防ぐためにz軸は+1の余裕値を持つ。
            if (closeTarget.transform.position.z > this.transform.position.z+1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (closeTarget.transform.position.z+1 < this.transform.position.z)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
