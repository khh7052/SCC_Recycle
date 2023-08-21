using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    public float height = -5f;
    void Update()
    {
        if(transform.position.y < height) gameObject.SetActive(false);
    }
}
