using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxExitButton : MonoBehaviour
{
    [SerializeField] BoxPanel boxPanel;
    [SerializeField] BoxSlot boxSlot ;
    public void ExitStore()
    {
        boxPanel.gameObject.SetActive(false);
        GameManager.instance.StageClear();
        boxSlot.ResetSlot();
        boxSlot.gameObject.SetActive(true);
       

    }
}
