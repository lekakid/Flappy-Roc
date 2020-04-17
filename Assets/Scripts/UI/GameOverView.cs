﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    public Text txtScore;
    public Text txtBestScore;
    public Image imgMedal;
    public Image imgFail;
    public Image imgClear;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowMedal() {
        if(GameManager.Instance.Score >= GameManager.Instance.MedalScore) {
            imgMedal.enabled = true;
        }
    }

    public void SetMissionClear() {
        bool result = GameManager.Instance.Score >= GameManager.Instance.MedalScore;

        imgFail.enabled = !result;
        imgClear.enabled = result;
    }

    public void SetScore(int Score, int BestScore) {
        txtScore.text = string.Format("{0}", Score);
        txtBestScore.text = string.Format("{0}", BestScore);
    }
}
