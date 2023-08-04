using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public int count = 0;
    public float speed = 1f;

    void Start()
    {
        count = transform.childCount;
    }

    void Update()
    {
        transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
    }
}
