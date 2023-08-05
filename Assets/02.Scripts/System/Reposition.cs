using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reposition : MonoBehaviour
{
    public UnityEvent OnReposition;
    public float repositionPoint = -10f;
    public float moveX = 21f;

    void LateUpdate()
    {
        if (transform.position.x > repositionPoint) return;

        transform.Translate(moveX, 0, 0);
        // transform.position = new Vector3 (moveX, transform.position.y, transform.position.z);
        OnReposition.Invoke();
    }

}
