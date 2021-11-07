using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Spriptables/Lighting Preset", order = 1)]
public class LightingPreset : ScriptableObject
{
    public Gradient _AmbientColor;
    public Gradient _DirectionalColor;
    public Gradient _FogColor;
}
