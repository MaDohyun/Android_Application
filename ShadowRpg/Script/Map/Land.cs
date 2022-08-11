using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    //landの上にあるボタン
    [SerializeField] GameObject landbutton;
    [SerializeField] IconGenerator iconGenerator;
    [SerializeField] GameObject map;
    //プレイヤーがマップで動くスピード
    [SerializeField] int moveSpeed;
    [SerializeField] GameObject player;
    //アイコンが現れる位置
    Vector3 iconVector3;
    //landがプレイヤーの目的地であるかどうか
    bool selectedLand;
    MapIcon icon;
    //landのレベル、これによりバトルレベルが変わる。
    [SerializeField ]int Level;
    //landを活性化させるかどうか
    public bool landOn;
    void Start()
    {
        landOn = false;
        iconVector3 = new Vector3(transform.position.x, transform.position.y+30);
        icon = iconGenerator.IconGenerate(this.gameObject.transform);
        icon.transform.position = iconVector3;
    }

    // Update is called once per frame
    void Update()
    {

        if (landOn)
        {
            landbutton.SetActive(true);
        }
        if (!selectedLand)
        {
            if (!landOn)
            {
                landbutton.SetActive(false);
            }
        }
    }
    //プレイヤーがlandを押すとこのlandがプレイヤーの目的地になり、プレイヤーはここをむいてくる。
    public void MoveComeHere()
    {
      
        if (GameManager.instance.mapState == GameManager.MapState.Move)
        {
            player.GetComponent<MapPlayer>().SetDestination(this.gameObject, moveSpeed);
            
            selectedLand = true;
            GameManager.instance.MapDestination = this.gameObject;
            //目的地が決まるとクリアするまで他のlandにはいけない
            GameManager.instance.mapState = GameManager.MapState.StageClearNot;
            GameManager.instance.battleLevel = Level;
        }
    }

    public void DestroyButton()
    {
        Destroy(landbutton);
    }

}
