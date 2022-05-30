using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapSceneCanvas : MonoBehaviour
{
   
    public static MapSceneCanvas instance = null;
    // Start is called before the first frame update
    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
                    }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MapScene")
        {
            this.gameObject.SetActive(false);
        }
    }

    }
