using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using com;

public class CanvasObject : UIBehaviour, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerClickHandler
{
    public enum InteractionType
    {
        None = 0,
        Drag_Inside_Horizontal = 1,
        Drag_Inside_Vertical = 2,
        Drag_Inside_All = 3,
        Drag_CreateCanvas = 12,
        Hover_ChangeMat=20,
    }

    RectTransform _rect;
    public InteractionType interactionType;
    bool _isDraging;
    Vector2 _dragStartAnchoredPos;
    Vector2 _dragStartMousePos;

    public Config_Drag_Inside_Horizontal config_Drag_Inside_Horizontal;
    public Config_Drag_CreateCanvas config_Drag_CreateCanvas;
    public Config_Hover_ChangeMat  config_Hover_ChangeMat;

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
            else if (interactionType == InteractionType.Drag_CreateCanvas)
            {
                //  var cfg = config_Drag_CreateCanvas;
                //  var delta = eventData.position - _dragStartMousePos;
                //  var targetPos = _dragStartAnchoredPos + delta;
                //  _rect.anchoredPosition = targetPos;
            }
        }
    }

    private void Update()
    {
        if (_isDraging)
        {
            if (interactionType == InteractionType.Drag_CreateCanvas)
            {
                var mousePos = Input.mousePosition;
                var cfg = config_Drag_CreateCanvas;
                var delta = (Vector2)mousePos - _dragStartMousePos;
                var targetPos = _dragStartAnchoredPos + delta;
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
        if (interactionType == InteractionType.Hover_ChangeMat)
        {
            config_Hover_ChangeMat.img.material = config_Hover_ChangeMat.hover;
        }
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (interactionType == InteractionType.Hover_ChangeMat)
        {
            config_Hover_ChangeMat.img.material = config_Hover_ChangeMat.normal;
        }

        if (interactionType == InteractionType.Drag_Inside_Horizontal)
        {
            EndDrag();
        }
        else if (interactionType == InteractionType.Drag_CreateCanvas)
        {
            //EndDrag();
        }
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
            SoundSystem.instance.Play("dragStart");
        }
        else if (interactionType == InteractionType.Drag_CreateCanvas)
        {
            _isDraging = true;
            _dragStartMousePos = eventData.position;

            _rect.SetParent(CanvasSystem.instance.globalParent);
            _dragStartAnchoredPos = _rect.anchoredPosition;
            var blinker = CanvasSystem.instance.GetCanvas(config_Drag_CreateCanvas.pos).blinker;
            blinker.SetActive(true);
            SoundSystem.instance.Play("dragStart");
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("OnPointerUp");
        if (!_isDraging)
            return;
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
                SoundSystem.instance.Play("dragEnd");
            }
        }
        else if (interactionType == InteractionType.Drag_CreateCanvas)
        {
            if (_isDraging)
            {
                var c = CanvasSystem.instance.GetCanvas(config_Drag_CreateCanvas.pos);
                c.SetBg(config_Drag_CreateCanvas.mainSp);
                c.Show();
                _isDraging = false;
                SoundSystem.instance.Play("createCanvas");
            }
        }
    }
}