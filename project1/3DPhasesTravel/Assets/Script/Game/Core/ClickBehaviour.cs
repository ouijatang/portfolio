using UnityEngine;

public enum OutlineStyle
{
    None,
    DefaultWidth,
    Thin,
    Thick,
}

public enum CubeAxis
{
    None,
    One,
    Two,
}

public class ClickBehaviour : MonoBehaviour
{
    OutlineStyle _outlineStyle;
    public bool interactable;
    ClickFeedback _feedback;
    public CubeAxis cubeAxis;

    public OutlineStyle outlineStyle
    {
        get
        {
            return _outlineStyle;
        }
        set
        {
            _outlineStyle = value;
            //Debug.Log(_outlineStyle);
            switch (_outlineStyle)
            {
                case OutlineStyle.None:
                    _outline.OutlineWidth = 0;
                    break;
                case OutlineStyle.DefaultWidth:
                    outlineStyle = interactable ? OutlineStyle.Thin : OutlineStyle.None;
                    break;
                case OutlineStyle.Thin:
                    _outline.OutlineWidth = 1;
                    break;
                case OutlineStyle.Thick:
                    _outline.OutlineWidth = 5;
                    break;
            }
        }
    }

    Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public void Start()
    {
        outlineStyle = OutlineStyle.DefaultWidth;
    }

    public void OnClicked()
    {
        Debug.Log("click " + gameObject.name);

        if (interactable)
        {
            switch (cubeAxis)
            {
                case CubeAxis.None:
                    break;
                case CubeAxis.One:
                    if (CameraSystem.instance.axis == CubeAxis.One)
                        PlayerBehaviour.instance.TryJumpToCube(this);

                    CameraSystem.instance.SetToAxis1(CameraSystem.instance.GetCamPos(PlayerBehaviour.instance.GetCurrentCubePositionIgnoreMovement(), cubeAxis));
                    break;
                case CubeAxis.Two:
                    if (CameraSystem.instance.axis == CubeAxis.Two)
                        PlayerBehaviour.instance.TryJumpToCube(this);

                    CameraSystem.instance.SetToAxis2(CameraSystem.instance.GetCamPos(PlayerBehaviour.instance.GetCurrentCubePositionIgnoreMovement(), cubeAxis));
                    break;
            }

            if (_feedback == null)
                _feedback = GetComponent<ClickFeedback>();
            if (_feedback != null)
            {
                if (!_feedback.locked)
                    _feedback.OnClicked();
            }
        }
    }
}
