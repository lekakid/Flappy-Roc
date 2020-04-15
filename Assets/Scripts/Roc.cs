using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roc : MonoBehaviour
{
    public float FlyForce;
    public float Speed;

    Rigidbody2D _rigidbody;
    Vector2 _DefaultPosition;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _DefaultPosition = transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Fly();
        }
    }

    public void Init() {
        transform.position = _DefaultPosition;
    }

    public void Fly() {
        if(GameManager.Instance.State == GameManager.StateType.INIT) {
            GameManager.Instance.Play();
        }

        if(GameManager.Instance.State == GameManager.StateType.PLAY) {
            SoundManager.Instance.Play("jump");
            _rigidbody.velocity = Vector2.up * FlyForce;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall")) {
            SoundManager.Instance.Play("die");
            GameManager.Instance.GameOver();
        }

        if(other.CompareTag("Gate")) {
            GameManager.Instance.GetScore();
        }
    }
}
