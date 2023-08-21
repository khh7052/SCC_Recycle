using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public Vector2 dir;
    public float speed = 5f;

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(speed * Time.fixedDeltaTime * dir);
    }
}
