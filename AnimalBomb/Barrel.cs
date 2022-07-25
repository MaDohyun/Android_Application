using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//爆弾のような扱いの破壊できるブロックのクラス
public class Barrel : MonoBehaviour
{
    //威力（ゲームの中に一番強い威力である。）
    public int BarrelExplosionPower = 11;
    //ボームを調べるためのlayer
    public LayerMask bombLayer;
    bool barrelActive = false;
    // Start is called before the first frame update
    private void Start()
    {
        if (!barrelActive)
        {
            SetBarrel();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //範囲内にボームがあるか確認する。これはCPUがこのオブジェクトをボームとして認識できるようにする設定である。
        //tagもボームに変えてlayer = 10はBombsである。
        if (DetectBomb())
        {
            this.gameObject.tag = "Bomb";
            this.gameObject.layer = 10;
        }
    }
    //爆弾の初期設定
    void SetBarrel()
    {
        this.gameObject.GetComponent<Bomb>().explosionPower = BarrelExplosionPower;
        //爆発予定ならキャンセルする。
        this.gameObject.GetComponent<Bomb>().CancelInvoke("Explode");
        //そのままでは爆発しないようにタイムは999に設定する。
        this.gameObject.GetComponent<Bomb>().explosionTime = 999;
        //爆弾の製作者は自分自身にする。
        this.gameObject.GetComponent<Bomb>().maker = this.gameObject;
        //設定が終わると重複実行を防止する。
        barrelActive = true;
    }
    //範囲内にボームがあるか確認する。これはCPUがこのオブジェクトをボームとして認識できるようにする設定である。
    //調べる時はゲーム内一番強い威力を持つ自分の威力範囲から調べる。
    public bool DetectBomb()
    {
        RaycastHit hit;
        Physics.Raycast
        (
            transform.position + new Vector3(0, 0f, 0), Vector3.forward, out hit, BarrelExplosionPower-1
        );
        if (hit.collider)
        {
            if (hit.collider.tag == "Bomb")
            {

                if (DetectBombDanger(Vector3.forward))
                {
                    return true;
                }
            }
        }
        Physics.Raycast
        (
            transform.position + new Vector3(0, 0f, 0), Vector3.back, out hit, BarrelExplosionPower-1
        );
        if (hit.collider)
        {
            if (hit.collider.tag == "Bomb")
            {

                if (DetectBombDanger(Vector3.back))
                {
                    return true;
                }
            }
        }
        Physics.Raycast
        (
            transform.position + new Vector3(0, 0f, 0), Vector3.left, out hit, BarrelExplosionPower-1
        );
        if (hit.collider)
        {
            if (hit.collider.tag == "Bomb")
            {

                if (DetectBombDanger(Vector3.left))
                {
                    return true;
                }
            }
        }
        Physics.Raycast
        (
            transform.position + new Vector3(0, 0f, 0), Vector3.right, out hit, BarrelExplosionPower-1
        );
        if (hit.collider)
        {
            if (hit.collider.tag == "Bomb")
            {

                if (DetectBombDanger(Vector3.right))
                {
                    return true;
                }
            }
        }
        return false;
    }

    //範囲内にボームがあると、そのボームの爆発が自分の位置まで到達するか確認する。
    public bool DetectBombDanger(Vector3 direction)
    {
        RaycastHit bombHit;
        for (int i = 0; i < BarrelExplosionPower; i++)
        {
            Physics.Raycast(transform.position + new Vector3(0, 0f, 0), direction, out bombHit, i, bombLayer);
            if (bombHit.collider)
            {
                if (bombHit.collider.gameObject.GetComponent<Bomb>() != null)
                {
                    //ボームの威力が距離より高い場合、ボームがあると判定する。
                    if (bombHit.collider.gameObject.GetComponent<Bomb>().explosionPower > i)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        return false;
    }
}

       
