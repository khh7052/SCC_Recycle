using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public Vector3 rotateAxis = Vector3.up;

    private void Awake()
    {
        rotateAxis.Normalize();
    }

    void FixedUpdate()
    {
        transform.Rotate(Time.fixedDeltaTime * rotateSpeed * rotateAxis);
    }
}
