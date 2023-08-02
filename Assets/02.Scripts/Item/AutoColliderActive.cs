using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoColliderActive : MonoBehaviour
{
    public float activeDelay;
    private Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        Invoke(nameof(ActiveCollider), activeDelay);
    }

    private void OnDisable()
    {
        CancelInvoke();
        coll.enabled = false;
    }


    void ActiveCollider()
    {
        if (coll == null) return;
        coll.enabled = true;
    }
}
