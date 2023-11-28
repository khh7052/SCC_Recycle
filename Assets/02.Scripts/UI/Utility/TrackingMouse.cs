using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMouse : MonoBehaviour
{
    
    public Vector3 offset;
    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        Vector2 position = Input.mousePosition + offset;

        // Canvas에 대한 마우스 위치를 계산
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, position, canvas.worldCamera, out position);

        // UI 요소를 마우스 위치로 이동
        rectTransform.position = canvas.transform.TransformPoint(position);
    }
}
