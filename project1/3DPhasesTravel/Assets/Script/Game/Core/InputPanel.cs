using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InputPanel : UIBehaviour, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerClickHandler
{
    public static InputPanel instance { get; private set; }
    public RectTransform canvasTrans;

    private float _timestampTap;
    public float canvasScale { get; private set; }

    private Vector2 _delta;
    private Vector2 _dragStartPos;
    public bool IsDraging { get; private set; }
    private Vector2 startPos;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        canvasScale = canvasTrans.localScale.x;
    }

    public Vector2 GetDelta()
    {
        //if (!IsDraging)
        //{
        //    return Vector2.zero;
        //}
        return _delta;
    }

    public void OnDrag(PointerEventData eventData)
    {
        IsDraging = true;
        _delta += eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickSystem.instance.InputPanelDown(eventData);
        //Debug.Log("OnPointerDown");
        _timestampTap = Time.unscaledTime;
        _delta = Vector2.zero;
        _dragStartPos = eventData.position;
    }

    public Vector2 GetStartPos()
    {
        return _dragStartPos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        // IsDraging = false;
        //   _delta = Vector2.zero;
        //   longPressController.OnRelease();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ClickSystem.instance.InputPanelRelease(eventData);
        IsDraging = false;
        _delta = Vector2.zero;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickSystem.instance.InputPanelClick(eventData);
    }
}