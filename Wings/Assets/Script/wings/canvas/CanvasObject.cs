using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
//using com;

public class CanvasObject : UIBehaviour, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerClickHandler
{
    public enum HoverType
    {
        None=0,
        Highlight=1,

    }

    public enum InteractionType
    {
        None = 0,
        Drag_Inside_Horizontal=1,
        Drag_Inside_Vertical = 2,
        Drag_Inside_All= 3,
        Drag_New_LT= 10,
        Drag_New_RT = 11,
        Drag_New_LB = 12,
        Drag_New_RB = 13,
    }

    public InteractionType interactionType;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }
}
