using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    int timerFlag;
    private float elapsedTime; // �o�ߎ��Ԃ��i�[����ϐ�

    void Start()
    {
        //�^�C�}�[�Ǘ��ϐ�
        timerFlag = -1;
        //�\���X�R�A�ϐ�
        scoreText.text = "0.00";
    }

    void Update()
    {
        if (timerFlag > 0)
        {
            // �o�ߎ��Ԃ��i�[
            elapsedTime += Time.deltaTime;
            // �^�C�}�[�̍X�V
            scoreText.text = "Score:"+elapsedTime.ToString("0.00");
        }
    }

    public void TimerSwitch()
    {
        //�^�C�}�[ON/OFF�؂�ւ�
        timerFlag *= -1;

        //�^�C�}�[OFF���ɃX�R�A���L�^
        if (timerFlag < 0)
        {
            //�O�X�e�[�W�X�R�A�Ɍ��X�e�[�W�X�R�A�����Z
            elapsedTime += PlayerPrefs.GetFloat("Score");
            //�X�R�A�����X�V
            PlayerPrefs.SetFloat("Score",elapsedTime);
        }
    }
}
