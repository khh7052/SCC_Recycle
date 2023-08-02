using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    public float ghostDelay = 0.2f;
    public float destroyTime = 0.5f;
    public Animator ghostPlayAnimator;
    public GhostEffectObject ghostEffect;

    void OnEnable()
    {
        StartCoroutine(MakeGhost());
    }

    private void OnDisable()
    {
        if (!Application.isPlaying) return;
        StopCoroutine(MakeGhost());
    }

    IEnumerator MakeGhost()
    {
        WaitForSeconds wait = new(ghostDelay);
        while (true)
        {
            yield return wait;
            ghostEffect.target = ghostPlayAnimator;
            PoolManager.Instance.Pop(ghostEffect.gameObject, transform.position, transform.rotation);
        }
    }
}
