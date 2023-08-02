using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorController : MonoBehaviour
{
    SkinnedMeshRenderer[] skinnedMeshRenderers;

    public void SetCharacterColor(Color color)
    {
        if(skinnedMeshRenderers == null)
        {
            skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        }

        foreach (var skinnedMeshRenderer in skinnedMeshRenderers)
        {
            skinnedMeshRenderer.material.SetColor("_SkinTint", color);
        }
    }
}
