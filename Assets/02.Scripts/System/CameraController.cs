using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float shakeDistance = 0.1f;
    public float shakeSpeed = 1f;

    Vector3 initialPosition;
    Vector3 shakeOffset;
    public bool isShaking = false;

    private Coroutine shakeCamCoroutine;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void StartShakeCamera(float shakeTime)
    {
        shakeCamCoroutine = StartCoroutine(ShakeCamera(shakeTime));
    }

    public void StopShakeCamera()
    {
        if (shakeCamCoroutine == null) return;
        StopCoroutine(shakeCamCoroutine);
        shakeCamCoroutine = null;
        transform.position = initialPosition;
        isShaking = false;
    }

    IEnumerator ShakeCamera(float time)
    {
        if (isShaking) yield break;

        isShaking = true;

        while (time > 0f)
        {
            Vector3 pos = transform.position;
            Vector3 offsetPos = pos + shakeOffset;
            float currentDistance = offsetPos.y - initialPosition.y;

            if (shakeSpeed >= 0)
            {
                if (currentDistance > shakeDistance)
                {
                    shakeSpeed *= -1;
                }
            }
            else
            {
                if (currentDistance < -shakeDistance)
                {
                    shakeSpeed *= -1;
                }
            }

            shakeOffset.y += shakeSpeed * Time.deltaTime;

            shakeOffset.y = Mathf.Clamp(shakeOffset.y, -shakeDistance, shakeDistance);
            transform.position = initialPosition + shakeOffset;

            time -= Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition;

        isShaking = false;
    }
}
