using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ゲームの結果のシーンを管理するクラス
public class ResultManager : MonoBehaviour
{
    [SerializeField] GameObject victoryImage;
    [SerializeField] Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //結果のシーンになるとGameManagerの子クラスであるモードクラスの子オブジェクト(キャラクターモデル)を習得する。
        if (GameManager.instance.transform.childCount > 0)
        {
            if (GameManager.instance.transform.GetChild(0).childCount > 0)
            {
                GameObject victoryModel = GameManager.instance.transform.GetChild(0).GetChild(0).gameObject;
                //モデルを決まっている位置に設定させ、アニメを設定する。
                victoryModel.SetActive(true);
                victoryModel.transform.rotation = Quaternion.Euler(0, 90, 0);
                victoryModel.transform.position = new Vector3(0, -1, 1);
                victoryModel.GetComponent<Animator>().SetBool("isMove", true);
            }
        }
        //VSモードの場合はスコアテキストはいらないため隠す。
        if(GameManager.instance.modeType == GameManager.ModeType.vs)
        {
            victoryImage.SetActive(true);
            scoreText.gameObject.SetActive(false);
        }
        //Survivalモードの場合はvictoryImageはいらないため隠してスコアを表示する。
        else if (GameManager.instance.modeType == GameManager.ModeType.survival)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Score : " + (int)GameManager.instance.mode.GetComponent<SurvivalModeManager>().score;

        }
    }

}
