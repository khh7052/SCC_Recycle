using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public Vector2 localTarget = Vector2.up;
    private Vector2 globalTarget;
    public float arrivalTime; // µµÂø½Ã°£
    private float speed;

    private void OnEnable()
    {
        globalTarget = (Vector2)transform.position + localTarget;
        speed = Vector2.Distance(Vector2.zero, localTarget) / arrivalTime;

        StopAllCoroutines();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Vector2 destination = (Vector2)transform.position + localTarget; // µµÂøÁöÁ¡
        float time = 0;
        while (arrivalTime > time)
        {
            time += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (Application.isPlaying)
        {
            Gizmos.DrawWireSphere(globalTarget, 0.2f);
        }
        else
        {
            Gizmos.DrawWireSphere((Vector2)transform.position + localTarget, 0.2f);
        }
        
    }

}
