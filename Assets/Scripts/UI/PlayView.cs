using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayView : MonoBehaviour
{
    public Text txtScore;
    public GameObject imgLight;
    public GameObject imgTouch;
    public Text txtCount;

    Animator animator;

    float count;
    float test;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(Mathf.CeilToInt(count) > 0) {
            count -= Time.unscaledDeltaTime;
            txtCount.text = string.Format("{0}", Mathf.CeilToInt(count));
        } else {
            if(GameManager.Instance.State == GameManager.StateType.RESUME) {
                txtCount.enabled = false;
                GameManager.Instance.SetPlayState();
            }
        }
    }

    public void SetScoreText(int score) {
        txtScore.text = string.Format("{0}", score);
    }

    public void Show(bool active) {
        animator.SetBool("ShowScore", active);
        animator.SetBool("ShowPauseButton", active);
    }

    public void ShowLight(bool active) {
        imgLight.SetActive(active);
        imgTouch.SetActive(active);
    }

    public void CountDown() {
        count = 3f;
        txtCount.enabled = true;
    }
}
