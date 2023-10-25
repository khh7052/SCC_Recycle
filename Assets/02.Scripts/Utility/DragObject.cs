using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Animator anim;
    private Collider2D coll;
    private Vector3 offset;

    public bool OnDrag
    {
        get { return enabled; }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void OnMouseEnter()
    {
        if (!OnDrag) return;

        if (anim) anim.SetBool("OnMouse", true);
    }

    private void OnMouseExit()
    {
        if (!OnDrag) return;

        if (anim) anim.SetBool("OnMouse", false);
    }

    private void OnMouseDown()
    {
        if (!OnDrag) return;

        coll.enabled = false;
        //coll.isTrigger = true;
        offset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (!OnDrag) return;

        transform.position = GetMousePos() + offset;
    }

    private void OnMouseUp()
    {
        if (!OnDrag) return;

        transform.position = GetMousePos() + offset;
        //coll.isTrigger = false;
        coll.enabled = true;
    }

    Vector3 GetMousePos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        return pos;
    }

}
