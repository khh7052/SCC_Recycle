using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpriteColorSetting))]
public class SpriteColorSettingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SpriteColorSetting spriteColorSetting = (SpriteColorSetting)target;
        if(GUILayout.Button("Color Setting"))
        {
            spriteColorSetting.ColorSetting();
        }

        if (GUILayout.Button("Size Setting"))
        {
            spriteColorSetting.SizeSetting();
        }
    }
}
