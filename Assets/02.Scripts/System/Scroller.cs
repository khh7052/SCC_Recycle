using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public int count = 0;
    public float speedRate = 1f;

    void Start()
    {
        count = transform.childCount;
    }

    void Update()
    {
        float totalSpeed = GameManager.globalSpeed * speedRate * -1 * Time.deltaTime;
        transform.Translate(totalSpeed, 0, 0);
    }
}
