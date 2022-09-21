using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    //�X�R�A�\���p
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        //�n�C�X�R�A�̍X�V
        string StageScore = "HighScore" + TitleController.StageNumber.ToString();
        if (PlayerPrefs.GetFloat("Score") < PlayerPrefs.GetFloat(StageScore))
        {
            PlayerPrefs.SetFloat(StageScore, PlayerPrefs.GetFloat("Score"));
        }
        
        //�X�R�A�̕\��
        scoreText.text = "Total Score : " + PlayerPrefs.GetFloat("Score").ToString("0.00") + "s";
        //�n�C�X�R�A�̕\��
        highScoreText.text = "High Score : " + PlayerPrefs.GetFloat(StageScore).ToString("0.00") + "s";
    }

    public void OnTitleButtonClick()
    {
        //Title�{�^�������ŃV�[���J��
        SceneManager.LoadScene("Title");
    }
}
