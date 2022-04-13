using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRoundMove : MonoBehaviour
{
    public float LeftRoundspeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * LeftRoundspeed * Time.deltaTime;//(-1,0,0)
        
    }
}
