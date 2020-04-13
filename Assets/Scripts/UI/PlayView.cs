using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayView : MonoBehaviour
{
    public Text txtScore;
    public GameObject imgLight;
    public GameObject imgTouch;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
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
}
