using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(Vector2.left * Time.deltaTime);

        if(transform.position.x <= -3f) {
            transform.position += (Vector3)(Vector2.right * 12f);
        }
    }
}
