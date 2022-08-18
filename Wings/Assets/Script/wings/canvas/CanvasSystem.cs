using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSystem : MonoBehaviour
{
    public static CanvasSystem instance;

    public Image Canvas_LT;
    public Image Canvas_RT;
    public Image Canvas_LB;
    public Image Canvas_RB;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public Image GetCanvas(int i)
    {
        switch (i)
        {
            case 1:
                return Canvas_LT;

            case 2:
                return Canvas_RT;

            case 3:
                return Canvas_LB;

            case 4:
                return Canvas_RB;
        }

        return null;
    }
}
