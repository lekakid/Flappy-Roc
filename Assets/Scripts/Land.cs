using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    void Update()
    {
        transform.position += (Vector3)(Vector2.left * GameManager.Instance.Roc.Speed * Time.deltaTime);

        if(transform.position.x <= 0) {
            transform.position += (Vector3)(Vector2.right * 2f);
        }
    }
}
