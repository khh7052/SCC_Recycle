using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiableActive : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
