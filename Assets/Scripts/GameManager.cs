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

        PlayView.SetScoreText(_score);
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
        _state = StateType.PLAY;
        PauseView.SetActive(false);
    }

    public void Restart() {
        _state = StateType.INIT;

        Roc.Init();
        GateRotator.Init();
        
        _score = 0;
        PlayView.SetScoreText(_score);
        PlayView.ShowLight(true);

        GameOverView.gameObject.SetActive(false);
    }

    public void GameOver() {
        _state = StateType.GAMEOVER;

        _bestScore = (_score > _bestScore) ? _score : _bestScore;

        PlayView.Show(false);
        GameOverView.gameObject.SetActive(true);
        GameOverView.SetScore(_score, _bestScore);
        GameOverView.ShowMedal();
    }

    public void Quit() {
        Application.Quit();
    }

    public void GetScore() {
        _score++;
    }
}
