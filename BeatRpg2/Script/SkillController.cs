using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{

    public Text skill1;
    public Text skill2;
    public Text skill3;

    public GameObject skillimage1;
    public GameObject skillimage2;
    public GameObject skillimage3;

    public float skill1count;
    public float skill2count;
    public int skill3count;
   
    public GameObject SkillArrow;
    RoundLeftGoodDestroyer rl;
    RoundRightGoodDestroyer rr;

    private bool skill3on;
    private AudioSource theaudio;

    [SerializeField] private AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        skill3on = false;
         skill1count = 10;
        skill2count = 20;
        skill3count = 10;
        theaudio = GetComponent<AudioSource>();
       

    }

    // Update is called once per frame
    void Update()
    {
        skill1.text = ""+skill1count;
        skill2.text = "" + skill2count;
        skill3.text = "Need Combo" + "\n" + skill3count;
         
        if (RoundController.combo >= 10)
        {
            skill3.gameObject.SetActive(false);
            skillimage3.gameObject.SetActive(true);
            skill3on  = true;
        }

        skill1count -= Time.deltaTime;
        skill2count -= Time.deltaTime;
    
       
        if (skill1count <= 0)
        {
            skill1.gameObject.SetActive(false);
            skillimage1.gameObject.SetActive(true);
        }
        if (skill2count <= 0)
        {
            skill2.gameObject.SetActive(false);
            skillimage2.gameObject.SetActive(true);
        }

        if (skill1count <= 0 && Input.GetKey(KeyCode.Q))
        {
            
            for (int i=0; i < 10; i++){
                float a = Random.RandomRange(0,3);
                
                Invoke("Skill1",a);
                PlayMusic(0);
            }

            skill1count = 10;
            skill1.gameObject.SetActive(true);
            skillimage1.gameObject.SetActive(false);
        }
        if (skill3on  && Input.GetKey(KeyCode.E))
        {
            for(int i = 0; i < PartyMember.Party.Count; i++)
            {
               
                PartyMember.Party[i].GetComponent<Character>().HP += 10;
            }
            PlayMusic(1);
            skill3on = false;
            RoundController.combo = 0;
            skill3.gameObject.SetActive(true);
            skillimage3.gameObject.SetActive(false);
        }


    }

    public void Skill1()
    {
        Instantiate(SkillArrow);
    }

   
    public void PlayMusic(int i)
    {
        theaudio.clip = clip[i];
        theaudio.Play();
    }
}

