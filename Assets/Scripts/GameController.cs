using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //ボール管理変数
    public GameObject ballRed;
    public GameObject ballblue;
    public GameObject ballGreen;

    //ホール管理変数
    public Hole holeRed;
    public Hole holeblue;
    public Hole holeGreen;

    //状態管理変数
    public Text stateText;

    //タイマー管理変数
    public ScoreController scoreController;

    //ゲームステート
    enum State
    {
        Ready,
        Play,
        GameClear
    }

    State state;

    void Start()
    {
        //開始と同時にReadyステートに移行
        Ready();
    }

    void LateUpdate()
    {
        //ゲームのステートごとにイベントを監視
        switch (state)
        {
            case State.Ready:
                //タッチしたらゲームスタート
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                    scoreController.TimerSwitch();      //タイマー開始
                }
                break;

            case State.Play:
                //全てのボールがホールに入ったらゲームクリア
                if (holeRed.IsHolding() && holeblue.IsHolding() && holeGreen.IsHolding()) GameClear();
                    break;

            case State.GameClear:
                //タッチしたらNextステージへ遷移
                if (Input.GetButtonDown("Fire1")) NextScene();
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;

        //Ballオブジェクトを無効状態にする
        ballRed.SetActive(false);
        ballblue.SetActive(false);
        ballGreen.SetActive(false);

        //ラベルの更新
        stateText.gameObject.SetActive(true);
        stateText.text = "Touch to start!";
    }

    void GameStart()
    {
        state = State.Play;

        //Ballオブジェクトを有効状態にする
        ballRed.SetActive(true);
        ballblue.SetActive(true);
        ballGreen.SetActive(true);

        //ラベルの更新
        stateText.gameObject.SetActive(false);
    }

    void GameClear()
    {
        state = State.GameClear;

        //Ballオブジェクトを無効状態にする
        ballRed.SetActive(false);
        ballblue.SetActive(false);
        ballGreen.SetActive(false);

        //タイマー終了
        scoreController.TimerSwitch();

        //ラベルの更新
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
        //最終ステージならResultシーンへ遷移
        if (0 == (SceneManager.GetActiveScene().buildIndex - 2) % 3 )
        {
            SceneManager.LoadScene("Result");
        }
        else
        {
            //次のステージへ遷移
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
