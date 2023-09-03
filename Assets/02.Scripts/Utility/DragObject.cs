using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Collider2D coll;
    private Vector3 offset;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        coll.enabled = false;
        offset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + offset;
    }

    private void OnMouseUp()
    {
        coll.enabled = true;
    }

    Vector3 GetMousePos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        return pos;
    }

}
