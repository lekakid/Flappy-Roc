using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roc : MonoBehaviour
{
    public float FlyForce;
    public float Speed;

    Rigidbody2D _rigidbody;
    bool _isReadyState = true;
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
        _isReadyState = true;
        transform.position = _DefaultPosition;
    }

    public void Fly() {
        if(_isReadyState) {
            GameManager.Instance.Play();
            _isReadyState = false;
        }

        if(GameManager.Instance.State == GameManager.StateType.PLAY)
            _rigidbody.velocity = Vector2.up * FlyForce;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall")) {
            GameManager.Instance.GameOver();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Gate")) {
            GameManager.Instance.GetScore();
        }
    }
}
