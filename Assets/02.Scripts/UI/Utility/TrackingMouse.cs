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

        // Canvas�� ���� ���콺 ��ġ�� ���
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, position, canvas.worldCamera, out position);

        // UI ��Ҹ� ���콺 ��ġ�� �̵�
        rectTransform.position = canvas.transform.TransformPoint(position);
    }
}
