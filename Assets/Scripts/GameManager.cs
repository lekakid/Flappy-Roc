using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Object")]
    public Roc Roc;
    public GateRotator GateRotator;

    [Header("View")]
    public PlayView PlayView;
    public GameObject PauseView;
    public GameOverView GameOverView;

    [Header("Value")]
    public int MedalScore = 200;

    #region Property
    public static GameManager Instance {
        get { return _instance; }
    }

    public StateType State {
        get { return _state; }
        set { _state = value; }
    }

    public int Score {
        get { return _score; }
    }
    #endregion

    #region Variable
    public enum StateType {
        INIT,
        PLAY,
        PAUSE,
        RESUME,
        GAMEOVER
    }
    static GameManager _instance;

    StateType _state = StateType.INIT;
    int _score = 0;
    int _bestScore = 0;
    #endregion

    void Awake()
    {
        _instance = this;

        Camera.main.orthographicSize = 3f * Screen.height / Screen.width;
    }

    void Update() {
        switch(_state) {
            case StateType.INIT:
            case StateType.PAUSE:
            case StateType.GAMEOVER:
                Time.timeScale = 0;
                break;
            case StateType.PLAY:
                Time.timeScale = 1;
                break;
        }
    }

    public void Play() {
        _state = StateType.PLAY;
        PlayView.Show(true);
        PlayView.ShowLight(false);
    }

    public void Pause() {
        _state = StateType.PAUSE;
        PauseView.SetActive(true);
    }

    public void Resume() {
        PauseView.SetActive(false);
        _state = StateType.RESUME;
        PlayView.CountDown();
    }

    public void SetPlayState() {
        _state = StateType.PLAY;
    }

    public void Restart() {
        _state = StateType.INIT;

        Roc.Init();
        GateRotator.Init();
        
        _score = 0;
        PlayView.SetScoreText(_score);
        PlayView.ShowLight(true);

        PauseView.SetActive(false);
        GameOverView.gameObject.SetActive(false);
    }

    public void GameOver() {
        _state = StateType.GAMEOVER;

        _bestScore = (_score > _bestScore) ? _score : _bestScore;

        PlayView.Show(false);
        GameOverView.gameObject.SetActive(true);
        GameOverView.SetScore(_score, _bestScore);
        GameOverView.SetMissionClear();
        GameOverView.ShowMedal();
    }

    public void Quit() {
        Application.Quit();
    }

    public void GetScore() {
        _score++;
        PlayView.SetScoreText(_score);
    }
}
