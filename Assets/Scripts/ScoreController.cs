using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    int timerFlag;
    private float elapsedTime; // 経過時間を格納する変数

    void Start()
    {
        //タイマー管理変数
        timerFlag = -1;
        //表示スコア変数
        scoreText.text = "0.00";
    }

    void Update()
    {
        if (timerFlag > 0)
        {
            // 経過時間を格納
            elapsedTime += Time.deltaTime;
            // タイマーの更新
            scoreText.text = "Score:"+elapsedTime.ToString("0.00");
        }
    }

    public void TimerSwitch()
    {
        //タイマーON/OFF切り替え
        timerFlag *= -1;

        //タイマーOFF時にスコアを記録
        if (timerFlag < 0)
        {
            //前ステージスコアに現ステージスコアを加算
            elapsedTime += PlayerPrefs.GetFloat("Score");
            //スコア情報を更新
            PlayerPrefs.SetFloat("Score",elapsedTime);
        }
    }
}
