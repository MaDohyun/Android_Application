using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundController : MonoBehaviour
{
    public GameObject leftround;
    public GameObject rightround;
    public GameObject roundAppearPosition;
    public GameObject RoundGood;
    public GameObject RoundLeftGoodDestroyer;
    public GameObject RoundRightGoodDestroyer;
    public Text ComboText;



    public static int combo;
    public int bpm = 0;
    Image image;
    [SerializeField] private float roundspeed;
    // Start is called before the first frame update
    void Start()
    {
        combo = 0;
        RoundLeftGoodDestroyer.SetActive(false);
        RoundRightGoodDestroyer.SetActive(false);
        image = RoundGood.GetComponent<Image>();
        leftround.GetComponent<RoundMove>().RoundSpeed = roundspeed;
        rightround.GetComponent<RoundMove>().RoundSpeed = roundspeed;
        roundAppearPosition.GetComponent<RoundGenerator>().bpm = bpm;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (combo >= 10)
        {
            ComboText.text = combo + "Combo!";
        }
        else if (combo < 10)
        {
            ComboText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RoundTargetEffectOn();
            TargetLeftDestroyerOn();
           
        }
      
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            RoundTargetEffectOff();
            TargetLeftDestroyerOff();
           
        }
         if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RoundTargetEffectOn();
            TargetRightDestroyerOn();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RoundTargetEffectOff();
            TargetRightDestroyerOff();
        }
        
    }
    public void RoundTargetEffectOn()
    { 
        Color color = image.color;
        color.a = 1f;
        image.color = color;
    }
    public void RoundTargetEffectOff()
    {
        Color color = image.color;
        color.a = 0.3f;
        image.color = color;
    }
    public void TargetLeftDestroyerOn()
    {
        RoundLeftGoodDestroyer.SetActive(true);
    }
    public void TargetLeftDestroyerOff()
    {
        RoundLeftGoodDestroyer.SetActive(false);
    }
    public void TargetRightDestroyerOn()
    {
        RoundRightGoodDestroyer.SetActive(true);
    }
    public void TargetRightDestroyerOff()
    {
        RoundRightGoodDestroyer.SetActive(false);
    }
}
