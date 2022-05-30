using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreExitButton : MonoBehaviour
{
    [SerializeField] StorePanel storePanel;
    [SerializeField] StoreSlot[] slots = new StoreSlot[3];
    public void ExitStore()
    {
        storePanel.gameObject.SetActive(false);
        GameManager.instance.StageClear();
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].ResetSlot();
            slots[i].gameObject.SetActive(true);
        }

    }
}
