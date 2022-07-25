using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//触れるとプレイヤーやcpuの速度を減少させるFlowerクラス。
public class Flower : MonoBehaviour
{
    Animator anim;
    [Header("Model")]
    public GameObject flowerModelObject;

    [Header("Vectors")]
    public Vector3 destination;

    [Header("Trigger")]
    public bool canAction = false;

    public float flowerSpeed = 2.5f;
    public int rayDistance = 3;
    public float timer = 3;
    GameObject target;
    bool scriptActive = false;
    void Start()
    {
        anim = flowerModelObject.GetComponent<Animator>();
    }
    private void Update()
    {
        DecideAction();
        if (canAction)
        {
            StartCoroutine(Move());
        }
    }
    //行動を決める。
    void DecideAction()
    {
        //ターゲットが決まるとターゲットがある方向を目的地にする。
        if (DetectTarget(Vector3.forward))
        {
            target = DetectTarget(Vector3.forward);
            destination = new Vector3(target.transform.position.x,transform.position.y, target.transform.position.z);
            canAction = true;
        }
        else if (DetectTarget(Vector3.back))
        {
            target = DetectTarget(Vector3.back);
            destination = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            canAction = true;
        }
        else if (DetectTarget(Vector3.left))
        {
            target = DetectTarget(Vector3.left);
            destination = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            canAction = true;
        }
        else if (DetectTarget(Vector3.right))
        {
            target = DetectTarget(Vector3.right);
            destination = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            canAction = true;
        }
        else
        {
            canAction = false;
        }
    }
    //動きのこルーチン
    private IEnumerator Move()
    {
        if (Vector3.Distance(destination, transform.position) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * flowerSpeed);
            anim.SetBool("isIdle", true);
        }
        else
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
        }
        canAction = false;
        yield return null;
    }
    //方向にあるターゲットを調べる。
        public GameObject DetectTarget(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast
        (
            transform.position + new Vector3(0, 0, 0), direction, out hit, rayDistance
        );
        //方向にプレイヤーやCPUがあればターゲットにする。
        if (hit.collider)
        {
            switch (hit.collider.tag)
            {
                case "Player":
                    return hit.collider.gameObject;
                case "CPU":
                    return hit.collider.gameObject;
                default:
                    return null;
            }
        }
        
        return null;
    }
    //このオブジェクトはプレイヤーやcpuに触れると速度を減少させる。
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
                other.GetComponent<Player>().playerSpeed -= 1;
                scriptActive = true;
          
        }
        if (other.CompareTag("CPU"))
        {
                other.GetComponent<CPU>().cpuSpeed -= 1;
                scriptActive = true;
        }
    }
    //プレイヤーやcpuがある程度離れると速度を戻す。
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                other.GetComponent<Player>().playerSpeed += 1;
                scriptActive = false;
        }
        if (other.CompareTag("CPU"))
        {
                other.GetComponent<CPU>().cpuSpeed += 1;
                scriptActive = false;
        }
    }
   
}
