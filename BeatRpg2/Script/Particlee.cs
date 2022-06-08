using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlee : MonoBehaviour
{
    public ParticleSystem p;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        p.Play();
    }
}
