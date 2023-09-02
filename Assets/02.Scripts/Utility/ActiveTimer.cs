using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTimer : MonoBehaviour
{
    public bool active = false;
    public float delay = 10f;

    private void OnEnable()
    {
        Invoke(nameof(Active), delay);
    }

    void Active()
    {
        gameObject.SetActive(active);
    }

}
