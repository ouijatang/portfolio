using UnityEngine;
using System.Collections.Generic;

public enum EventType
{
    None = 0,//delay only

    ShowHideActor = 1,
    FadeInOutActor = 2,

    MoveActor = 3,
    RotateActor = 4,
    ScaleActor = 5,

    SetSubIndex = 10,

    ShowHideCanvas = 13,
    FadeInOutCanvas = 15,

    TogglePlayAnimation = 21,

    ToggleInput = 30,
}

[CreateAssetMenu]
public class EventPrototype : ScriptableObject
{
    public float delay;//before play
    public EventType type;
    public EventPrototype next;
    public ActorPrototype actor;
    public EventValue v;
}

public struct EventValue
{
    public Vector3 vec3;
    public float f;
    public int i;
    public bool b;
    public string s;
}
