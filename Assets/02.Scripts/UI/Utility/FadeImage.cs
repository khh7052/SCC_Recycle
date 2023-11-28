using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public float fadeDelay = 1f;
    public float targetTime = 1f;
    public float startAlpha = 0f;
    public float endAlpha = 0f;
    private Image image;
    private Coroutine coroutine;
    private bool isFading = false;

    public float Alpha
    {
        get { return image.color.a; }
        set
        {
            Color c = image.color;
            c.a = value;
            image.color = c;
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ImageUpdate(Sprite sprite)
    {
        if (image == null) return;
        image.sprite = sprite;
    }

    public void StartFade()
    {
        if (image == null) return;
        if (isFading) StopFade();

        coroutine = StartCoroutine(Fade());
    }

    public void StopFade()
    {
        if (image == null) return;
        StopCoroutine(coroutine);
    }

    IEnumerator Fade()
    {
        isFading = true;
        Alpha = startAlpha;

        yield return new WaitForSeconds(fadeDelay);

        float time = 0f;
        while (time < targetTime)
        {
            time += Time.deltaTime;
            Alpha = Mathf.MoveTowards(Alpha, endAlpha, Time.deltaTime / targetTime);
            yield return null;
        }

        isFading = false;
    }

}
