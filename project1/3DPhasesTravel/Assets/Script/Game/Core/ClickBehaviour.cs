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
                    _outline.OutlineWidth = 2;
                    break;
                case OutlineStyle.Thick:
                    _outline.OutlineWidth = 8;
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
                    CameraSystem.instance.SetToAxis1(CameraSystem.instance.GetCamPos(transform.position, cubeAxis));
                    break;
                case CubeAxis.Two:
                    CameraSystem.instance.SetToAxis2(CameraSystem.instance.GetCamPos(transform.position, cubeAxis));
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
