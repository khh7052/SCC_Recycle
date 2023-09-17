using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour
{
    public float fadeDelay = 1f;
    public float targetTime = 1f;
    public float startAlpha = 0f;
    public float endAlpha = 0f;
    private TMP_Text text;
    private Coroutine coroutine;
    private bool isFading = false;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void TextUpdate(string str)
    {
        if (text == null) return;
        text.text = str;
    }

    public void StartFade()
    {
        if (text == null) return;
        if (isFading) StopFade();

        coroutine = StartCoroutine(Fade());
    }

    public void StopFade()
    {
        if (text == null) return;
        StopCoroutine(coroutine);
    }

    IEnumerator Fade()
    {
        isFading = true;
        text.alpha = startAlpha;
        yield return new WaitForSeconds(fadeDelay);

        float time = 0f;
        while (time < targetTime)
        {
            time += Time.deltaTime;
            text.alpha = Mathf.MoveTowards(text.alpha, endAlpha, Time.deltaTime / targetTime);
            yield return null;
        }

        isFading = false;
    }

}
