using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpController : MonoBehaviour
{
    //表示ハイスコア変数
    public Text[] HighScoreText;
    public GameObject popup;

    void Start()
    {
        //3ステージ分のスコア設定
        for (int i = 1; i <= 3; i++)
        {
            string s = "HighScore" + i.ToString();
            if (!PlayerPrefs.HasKey(s) || PlayerPrefs.GetFloat(s) >= 1000.0f)
            {
                //記録なし
                HighScoreText[i-1].text = "Stage" +i.ToString() +" : ----";
            }
            else
            {
                //ハイスコアを表示
                HighScoreText[i-1].text = "Stage" + i.ToString() + " : " + PlayerPrefs.GetFloat(s).ToString("0.00") + "s";
            }
        }
    }

    public void OnBackButtonClick()
    {
        //バックボタンクリックでタイトル画面に戻る
        SceneManager.LoadScene("Title");
    }

    public void OnHowToButtonClick(int i)
    {
        if (i == 0) 
        {
            popup.gameObject.SetActive(true);
        }
        else 
        { 
            popup.gameObject.SetActive(false);
        }
    }

    public void OnResetButtonClick()
    {
        //スコアリセット
        for (int i = 1; i <= 3; i++)
        {
            string s = "HighScore" + i.ToString();
            PlayerPrefs.DeleteKey(s);
            HighScoreText[i - 1].text = "Stage" + i.ToString() + " : ----";
        }
    }
}
