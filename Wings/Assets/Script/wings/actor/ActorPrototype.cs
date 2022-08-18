using UnityEngine;

[CreateAssetMenu]
public class ActorPrototype : ScriptableObject
{
    public Sprite img;
    public Color outlineColor;
    public bool isBg;
    public int subIndex;
    public bool receiveDrag;
    public bool receiveDrop;

}
