using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    //�I���X�e�[�W�Ǘ�
    public static int StageNumber;

    void Start()
    {
        //�X�R�A����������
        PlayerPrefs.SetFloat("Score", 0.0f);

        //�n�C�X�R�A�̏�����
        for (int i = 1; i <= 3; i++)
        {
            string s = "HighScore" + i.ToString();
            if (!PlayerPrefs.HasKey(s) || PlayerPrefs.GetFloat(s) >= 1000.0f)
                PlayerPrefs.SetFloat(s, 1000.0f);
        }
    }

    public void OnStartButtonClick(int num)
    {
        //�X�e�[�W�{�^�������ŃV�[���J��
        StageNumber = num;
        string StageName = "Stage" + num.ToString() + "-1";
        SceneManager.LoadScene(StageName);
    }

    public void OnHelpButtonClick()
    {
        //�w���v�{�^���N���b�N�Ńw���v��ʂɑJ��
        SceneManager.LoadScene("Help");
    }
}
