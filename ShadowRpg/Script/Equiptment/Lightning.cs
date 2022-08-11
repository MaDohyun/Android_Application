using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject,0.3f);
    }
}
