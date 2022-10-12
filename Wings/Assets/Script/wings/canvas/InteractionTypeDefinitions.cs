using UnityEngine;
using System.Collections;

[System.Serializable]
public class Config_Drag_Inside_Horizontal
{
    public float stepLength;
    public float minX;
    public float maxX;
    public CharacterActor[] walkers;
    public float speedRatio;
}
[System.Serializable]
public class Config_Drag_CreateCanvas
{
    public CanvasPosition pos;
    public Sprite mainSp;
}