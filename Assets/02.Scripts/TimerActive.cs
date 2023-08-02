using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerActive : MonoBehaviour
{
    public bool active = false;
    public float activeTime = 0.5f;

    private void OnEnable()
    {
        Invoke(nameof(Active), activeTime);
    }

    void Active()
    {
        gameObject.SetActive(active);
    }
}
