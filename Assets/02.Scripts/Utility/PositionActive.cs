using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionActive : MonoBehaviour
{
    public float limitPos = -20f;

    void Update()
    {
        if(transform.position.x <= limitPos)
        {
            gameObject.SetActive(false);
        }
    }


}
