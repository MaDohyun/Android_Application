using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selectmanager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
  
    public GameObject selectimage;
    public GameObject info;
    void Start()
    {
       
        selectimage.SetActive(false);
        info.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        selectimage.SetActive(true);
        info.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
      
        selectimage.SetActive(false);
        info.SetActive(false);
    }
}
