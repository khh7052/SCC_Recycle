using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (transform.position.x > -8) return;

        transform.Translate(15, 0, 0);
    }


}
