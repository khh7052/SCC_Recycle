using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrigger : MonoBehaviour
{
    public List<string> targetTags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var tag in targetTags)
        {
            if (collision.CompareTag(tag))
            {
                collision.gameObject.SetActive(false);
                break;
            }
        }
    }
}
