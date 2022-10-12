using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
//using com;

public class CanvasObject : UIBehaviour, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerClickHandler
{
    public enum HoverType
    {
        None = 0,
        Highlight = 1,

    }

    public enum InteractionType
    {
        None = 0,
        Drag_Inside_Horizontal = 1,
        Drag_Inside_Vertical = 2,
        Drag_Inside_All = 3,
        Drag_New_LT = 10,
        Drag_New_RT = 11,
        Drag_New_LB = 12,
        Drag_New_RB = 13,
    }

    RectTransform _rect;
    public InteractionType interactionType;
    bool _isDraging;
    Vector2 _dragStartAnchoredPos;
    Vector2 _dragStartMousePos;

    public Config_Drag_Inside_Horizontal config_Drag_Inside_Horizontal;


    protected override void Awake()
    {
        base.Awake();
        _rect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag " + eventData.delta);
        //Debug.Log(eventData.position);
        if (_isDraging)
        {
            if (interactionType == InteractionType.Drag_Inside_Horizontal)
            {
                var cfg = config_Drag_Inside_Horizontal;
                var delta = eventData.position - _dragStartMousePos;
                delta *= cfg.speedRatio;
                delta.y = 0;

                if (delta.x > cfg.stepLength)
                    delta.x = cfg.stepLength;
                if (delta.x < -cfg.stepLength)
                    delta.x = -cfg.stepLength;
                var targetPos = _dragStartAnchoredPos + delta;
                //Debug.Log(targetPos.x);
                targetPos.x = Mathf.Clamp(targetPos.x, cfg.minX, cfg.maxX);
                _rect.anchoredPosition = targetPos;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        EndDrag();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        //Debug.Log(eventData.position);
        if (interactionType == InteractionType.Drag_Inside_Horizontal)
        {
            _isDraging = true;
            _dragStartMousePos = eventData.position;
            _dragStartAnchoredPos = _rect.anchoredPosition;
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("OnPointerUp");
        EndDrag();
    }

    void EndDrag()
    {
        if (interactionType == InteractionType.Drag_Inside_Horizontal)
        {
            if (_isDraging)
            {
                //Debug.Log(_rect.anchoredPosition.x);
                //Debug.Log(_dragStartAnchoredPos.x);
                var delta = _rect.anchoredPosition - _dragStartAnchoredPos;
                foreach (var w in config_Drag_Inside_Horizontal.walkers)
                    w.Walk(delta.x);

                _isDraging = false;
            }
        }
    }
}