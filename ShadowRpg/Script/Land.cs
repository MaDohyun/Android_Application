using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    [SerializeField] GameObject landbutton;
    [SerializeField] IconGenerator iconGenerator;
    [SerializeField] GameObject map;
    [SerializeField] int moveSpeed;
    [SerializeField] GameObject player;
    Vector3 iconVector3;
    bool selectedLand;
    MapIcon icon;
    [SerializeField ]int Level;
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
        if (selectedLand != true)
        {
            if (!landOn)
            {
                landbutton.SetActive(false);
            }
        }
    }
    public void MoveComeHere()
    {
      
        if (GameManager.instance.mapState == GameManager.MapState.Move)
        {
            player.GetComponent<MapPlayer>().SetDestination(this.gameObject, moveSpeed);
            
            selectedLand = true;
            GameManager.instance.MapDestination = this.gameObject;
            GameManager.instance.mapState = GameManager.MapState.StageClearNot;
            GameManager.instance.battleLevel = Level;
        }
    }

    public void DestroyButton()
    {
        Destroy(landbutton);
    }




}
