using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorButton : MonoBehaviour
{
    public Texture2D cursorImage;

    public void ChangeCursor()
    {
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }
}
