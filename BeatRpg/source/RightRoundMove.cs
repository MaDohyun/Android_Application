using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRoundMove : MonoBehaviour
{
    public float RightRoundSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * RightRoundSpeed * Time.deltaTime;//(-1,0,0)
       
    }
}
