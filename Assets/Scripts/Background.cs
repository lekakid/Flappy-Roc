using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(Vector2.left * Time.deltaTime);

        if(transform.position.x <= 0) {
            transform.position += (Vector3)(Vector2.right * _spriteRenderer.bounds.size.x / 2f);
        }
    }
}
