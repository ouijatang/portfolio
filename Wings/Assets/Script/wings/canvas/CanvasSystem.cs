using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public enum CanvasPosition
{
    LT,
    RT,
    LB,
    RB
}

public class CanvasSystem : MonoBehaviour
{
    public static CanvasSystem instance;


    public RectTransform globalParent;
    public CanvasBehaviour canvas_LT;
    public CanvasBehaviour canvas_RT;
    public CanvasBehaviour canvas_LB;
    public CanvasBehaviour canvas_RB;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public CanvasBehaviour GetCanvas(CanvasPosition cp)
    {
        switch (cp)
        {
            case CanvasPosition.LT:
                return canvas_LT;
            case CanvasPosition.RT:
                return canvas_RT;
            case CanvasPosition.LB:
                return canvas_LB;
            case CanvasPosition.RB:
                return canvas_RB;
        }

        return null;
    }

    public void HideCanvas(CanvasPosition cp)
    {
        var c = GetCanvas(cp);
    }

    public void ShowCanvas(CanvasPosition cp)
    {
        var c = GetCanvas(cp);
    }
}
