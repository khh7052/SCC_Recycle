using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Vector2 dir = Vector2.left;
    public float speed = 1f;

    private HashSet<Transform> hitTransforms = new();

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        foreach (var item in hitTransforms)
        {
            item.transform.Translate(speed * Time.fixedDeltaTime * dir, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitTransforms.Contains(collision.transform)) return;
        hitTransforms.Add(collision.transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hitTransforms.Remove(collision.transform);
    }
}
