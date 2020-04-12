﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayView : MonoBehaviour
{
    public Text txtScore;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetScoreText(int score) {
        txtScore.text = string.Format("{0}", score);
    }

    public void ShowPauseButton(bool active) {
        animator.SetBool("ShowPauseButton", active);
    }

    public void ShowScore(bool active) {
        animator.SetBool("ShowScore", active);
    }
}
