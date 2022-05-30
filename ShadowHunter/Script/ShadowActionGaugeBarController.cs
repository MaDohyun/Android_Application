using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShadowActionGaugeBarController : MonoBehaviour
{
    [SerializeField]
    private Slider ActionGaguebar;
    [SerializeField]
    private Shadow shadow;

    private float maxActionGague;
    private float curActionGague;
    private float resulActionGague;


    // Start is called before the first frame update
    void Start()
    {
        shadow = shadow.GetComponent<Shadow>();
        maxActionGague = shadow.actionCooltime;
        curActionGague = shadow.actionDelay;
        ActionGaguebar.value = (float)curActionGague / (float)maxActionGague;
    }

    // Update is called once per frame
    void Update()
    {
        curActionGague = shadow.actionDelay;

        HandleHP();

    }
    private void HandleHP()
    {
        ActionGaguebar.value = Mathf.Lerp(ActionGaguebar.value, (float)curActionGague / (float)maxActionGague, Time.deltaTime * 10);
    }
}
