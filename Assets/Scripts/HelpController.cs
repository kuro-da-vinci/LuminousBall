using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpController : MonoBehaviour
{
    //�\���n�C�X�R�A�ϐ�
    public Text[] HighScoreText;
    public GameObject popup;

    void Start()
    {
        //3�X�e�[�W���̃X�R�A�ݒ�
        for (int i = 1; i <= 3; i++)
        {
            string s = "HighScore" + i.ToString();
            if (!PlayerPrefs.HasKey(s) || PlayerPrefs.GetFloat(s) >= 1000.0f)
            {
                //�L�^�Ȃ�
                HighScoreText[i-1].text = "Stage" +i.ToString() +" : ----";
            }
            else
            {
                //�n�C�X�R�A��\��
                HighScoreText[i-1].text = "Stage" + i.ToString() + " : " + PlayerPrefs.GetFloat(s).ToString("0.00") + "s";
            }
        }
    }

    public void OnBackButtonClick()
    {
        //�o�b�N�{�^���N���b�N�Ń^�C�g����ʂɖ߂�
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
        //�X�R�A���Z�b�g
        for (int i = 1; i <= 3; i++)
        {
            string s = "HighScore" + i.ToString();
            PlayerPrefs.DeleteKey(s);
            HighScoreText[i - 1].text = "Stage" + i.ToString() + " : ----";
        }
    }
}
