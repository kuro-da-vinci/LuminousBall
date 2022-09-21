using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    //選択ステージ管理
    public static int StageNumber;

    void Start()
    {
        //スコア情報を初期化
        PlayerPrefs.SetFloat("Score", 0.0f);

        //ハイスコアの初期化
        for (int i = 1; i <= 3; i++)
        {
            string s = "HighScore" + i.ToString();
            if (!PlayerPrefs.HasKey(s) || PlayerPrefs.GetFloat(s) >= 1000.0f)
                PlayerPrefs.SetFloat(s, 1000.0f);
        }
    }

    public void OnStartButtonClick(int num)
    {
        //ステージボタン押下でシーン遷移
        StageNumber = num;
        string StageName = "Stage" + num.ToString() + "-1";
        SceneManager.LoadScene(StageName);
    }

    public void OnHelpButtonClick()
    {
        //ヘルプボタンクリックでヘルプ画面に遷移
        SceneManager.LoadScene("Help");
    }
}
