using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += (Vector3)(Vector2.left * GameManager.Instance.Roc.Speed * Time.deltaTime);

        if(transform.position.x <= 0) {
            transform.position += (Vector3)(Vector2.right * _spriteRenderer.bounds.size.x / 2f);
        }
    }
}
