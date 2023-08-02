using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMove : MonoBehaviour
{
    public float moveSpeed = 10f;

    void FixedUpdate()
    {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDir.Normalize();

        transform.Translate(Time.fixedDeltaTime * moveSpeed * moveDir);
    }
}
