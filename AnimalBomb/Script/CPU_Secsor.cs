using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_Secsor : MonoBehaviour
{
    public CPU cPU;
    public Player player;

    [Header("LayerMasks")]
    public LayerMask bombLayer;
    //認識したボームの方向
    public List<Vector3> bombDirectionList;
    //物の種類
    public enum ObstacleType { empty , wall, destructablewall, bomb, player, cpu, item}
    //方向にある物の種類を判別する。
    public ObstacleType DetectObstacle(Vector3 direction, int rayDistance)
    {
            RaycastHit hit;
            Physics.Raycast
            (
                transform.position + new Vector3(0, 0.5f, 0), direction, out hit, rayDistance
            );
        //物がある場合
        if (hit.collider)
        {
            //物のtagのcase
            switch (hit.collider.tag)
            {
                case "DestructableWall":
                    return ObstacleType.destructablewall;
                case "Wall":
                    return ObstacleType.wall;
                case "Bomb":
                    return ObstacleType.bomb;
                case "Player":
                    return ObstacleType.player;
                case "CPU":
                    return ObstacleType.cpu;
                case "Item":
                    return ObstacleType.item;
                default:
                    return ObstacleType.empty;
            }
        }
        //種類に当てはまらない場合空いていると判別する。
        return ObstacleType.empty;
    }
    //方向にあるボームを調べる
    public bool DetectBomb(Vector3 direction)
    {
        //方向がもとの場所である場合
        if (direction == Vector3.zero)
        {
            RaycastHit startingPointBombHit;
            //上からしたにraycastを行ってボームを判別する。
            Physics.Raycast
            (
               new Vector3(Mathf.RoundToInt(transform.position.x),transform.position.y+3, Mathf.RoundToInt(transform.position.z)) , Vector3.down, out startingPointBombHit, 5, bombLayer
            );
            if (startingPointBombHit.collider)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            RaycastHit bombHit;
            //距離1からバームがあるか検索する。
            Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction, out bombHit, 1, bombLayer);
            if (bombHit.collider)
            {
                return true;
            }
            //最大ボーム威力の距離にボームがあるか検索する。
            else if (DetectObstacle(direction, cPU.cpuMaxExplosionPower-1) == ObstacleType.bomb)
            {
                //最大ボーム威力の距離にボームがある場合、詳しくバームの距離はどのくらいか判別する。
                for (int i = 0; i < cPU.cpuMaxExplosionPower; i++)
                {
                    RaycastHit Hit;
                    Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction, out Hit, i, bombLayer);
                    if (Hit.collider)
                    {
                        if (Hit.collider.gameObject.GetComponent<Bomb>() != null)
                        {
                            //ボームの威力が距離より高い場合、ボームがあると判定する。
                            if (Hit.collider.gameObject.GetComponent<Bomb>().explosionPower > i)
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
            }
            else
            {
                return false;
            }
                }
        return false;

    }
    //ボームの方向を調べる。
    public List<Vector3> DetectBombDirection()
    {
            bombDirectionList.RemoveRange(0, bombDirectionList.Count);
        if(DetectObstacle(Vector3.forward, cPU.cpuMaxExplosionPower - 1) == ObstacleType.bomb)
        {
            bombDirectionList.Add(Vector3.forward);
        }
        if (DetectObstacle(Vector3.left, cPU.cpuMaxExplosionPower - 1) == ObstacleType.bomb)
        {
            bombDirectionList.Add(Vector3.left);
        }
        if (DetectObstacle(Vector3.back, cPU.cpuMaxExplosionPower - 1) == ObstacleType.bomb)
        {
            bombDirectionList.Add(Vector3.back);
        }
        if (DetectObstacle(Vector3.right, cPU.cpuMaxExplosionPower - 1) == ObstacleType.bomb)
        {
            bombDirectionList.Add(Vector3.right);
        }
        //ボームがある全ての方向を返却する。
        return bombDirectionList;
    }
    }
