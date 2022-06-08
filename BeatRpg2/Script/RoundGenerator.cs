using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoundGenerator : MonoBehaviour
{
    public int bpm;
    double currentTime;
    int random;
    [SerializeField] Transform RoundAppearPosition = null;
    [SerializeField] GameObject LeftRound1 = null;
    [SerializeField] GameObject RightRound1 = null;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0d;
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 2);
        currentTime += Time.deltaTime;
        if(currentTime >= 60d / bpm)
        {
            if (random == 0)
            {
                GameObject rounde = Instantiate(LeftRound1, RoundAppearPosition.position, Quaternion.identity);
                rounde.transform.SetParent(this.transform);
                currentTime -= 60d / bpm;
            }
            else if (random == 1)
            {
                GameObject rounde = Instantiate(RightRound1, RoundAppearPosition.position, Quaternion.identity);
                rounde.transform.SetParent(this.transform);
                currentTime -= 60d / bpm;
            }
        } 
    }
}
