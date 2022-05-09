using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundMove : MonoBehaviour
{
    public float RoundSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * RoundSpeed * Time.deltaTime;//(-1,0,0)
    }
}
