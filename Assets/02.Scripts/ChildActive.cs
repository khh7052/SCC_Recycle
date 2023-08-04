using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildActive : MonoBehaviour
{
    public bool active = true;

    private Transform[] children;

    private void Start()
    {
        children = GetComponentsInChildren<Transform>();
    }

    public void ChildActiveUpdate()
    {
        foreach (var child in children)
        {
            child.gameObject.SetActive(active);
        }
    }

}
