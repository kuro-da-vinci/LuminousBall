using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //�{�[���Ǘ��ϐ�
    public GameObject ballRed;
    public GameObject ballblue;
    public GameObject ballGreen;

    //�z�[���Ǘ��ϐ�
    public Hole holeRed;
    public Hole holeblue;
    public Hole holeGreen;

    //��ԊǗ��ϐ�
    public Text stateText;

    //�^�C�}�[�Ǘ��ϐ�
    public ScoreController scoreController;

    //�Q�[���X�e�[�g
    enum State
    {
        Ready,
        Play,
        GameClear
    }

    State state;

    void Start()
    {
        //�J�n�Ɠ�����Ready�X�e�[�g�Ɉڍs
        Ready();
    }

    void LateUpdate()
    {
        //�Q�[���̃X�e�[�g���ƂɃC�x���g���Ď�
        switch (state)
        {
            case State.Ready:
                //�^�b�`������Q�[���X�^�[�g
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                    scoreController.TimerSwitch();      //�^�C�}�[�J�n
                }
                break;

            case State.Play:
                //�S�Ẵ{�[�����z�[���ɓ�������Q�[���N���A
                if (holeRed.IsHolding() && holeblue.IsHolding() && holeGreen.IsHolding()) GameClear();
                    break;

            case State.GameClear:
                //�^�b�`������Next�X�e�[�W�֑J��
                if (Input.GetButtonDown("Fire1")) NextScene();
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;

        //Ball�I�u�W�F�N�g�𖳌���Ԃɂ���
        ballRed.SetActive(false);
        ballblue.SetActive(false);
        ballGreen.SetActive(false);

        //���x���̍X�V
        stateText.gameObject.SetActive(true);
        stateText.text = "Touch to start!";
    }

    void GameStart()
    {
        state = State.Play;

        //Ball�I�u�W�F�N�g��L����Ԃɂ���
        ballRed.SetActive(true);
        ballblue.SetActive(true);
        ballGreen.SetActive(true);

        //���x���̍X�V
        stateText.gameObject.SetActive(false);
    }

    void GameClear()
    {
        state = State.GameClear;

        //Ball�I�u�W�F�N�g�𖳌���Ԃɂ���
        ballRed.SetActive(false);
        ballblue.SetActive(false);
        ballGreen.SetActive(false);

        //�^�C�}�[�I��
        scoreController.TimerSwitch();

        //���x���̍X�V
        if (0 == (SceneManager.GetActiveScene().buildIndex - 2) % 3)
        {
            stateText.gameObject.SetActive(true);
            stateText.text = "Clear!!";
        }
        else
        {
            stateText.gameObject.SetActive(true);
            stateText.text = "Next Stage";
        }
    }

    void NextScene()
    {
        //�ŏI�X�e�[�W�Ȃ�Result�V�[���֑J��
        if (0 == (SceneManager.GetActiveScene().buildIndex - 2) % 3 )
        {
            SceneManager.LoadScene("Result");
        }
        else
        {
            //���̃X�e�[�W�֑J��
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
