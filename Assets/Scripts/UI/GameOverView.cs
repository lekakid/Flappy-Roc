using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverView : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Show(bool active) {
        animator.SetBool("isShow", active);
    }
}
