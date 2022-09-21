using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    //スコア表示用
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        //ハイスコアの更新
        string StageScore = "HighScore" + TitleController.StageNumber.ToString();
        if (PlayerPrefs.GetFloat("Score") < PlayerPrefs.GetFloat(StageScore))
        {
            PlayerPrefs.SetFloat(StageScore, PlayerPrefs.GetFloat("Score"));
        }
        
        //スコアの表示
        scoreText.text = "Total Score : " + PlayerPrefs.GetFloat("Score").ToString("0.00") + "s";
        //ハイスコアの表示
        highScoreText.text = "High Score : " + PlayerPrefs.GetFloat(StageScore).ToString("0.00") + "s";
    }

    public void OnTitleButtonClick()
    {
        //Titleボタン押下でシーン遷移
        SceneManager.LoadScene("Title");
    }
}
