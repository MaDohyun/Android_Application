using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//AppleOrb装備の効果であるHealのクラス
public class Heal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyGameObject", 0.5f);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "BattleScene")
        {
            DestroyGameObject();
        }
    }
    public void DestroyGameObject()
    {
        Destroy(this);
    }
}
