using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSystem : MonoBehaviour
{
    public static ClickSystem instance;

    public ClickBehaviour[] cubes;
    public Camera mainCam;
    public Transform cubesParent;

    private void Awake()
    {
        instance = this;

        cubes = cubesParent.GetComponentsInChildren<ClickBehaviour>();
    }

    public void Refresh()
    {
        FadeAllOutline();
    }

    void FadeAllOutline()
    {
        foreach (var i in cubes)
        {
            if (i != null)
            {
                i.outlineStyle = OutlineStyle.DefaultWidth;
            }
        }
    }

    private ClickBehaviour GetPointerItem(PointerEventData eventData)
    {
        //Debug.Log("GetPointerItem " + eventData);
        RaycastHit raycastHit;
        Ray ray = mainCam.ScreenPointToRay(eventData.position);  //Check for mouse click  touch?
        if (Physics.Raycast(ray, out raycastHit, 100f))
        {
            if (raycastHit.transform != null)
            {
                //Debug.Log("transform! ");
                var go = raycastHit.transform.gameObject;
                //Debug.Log("PointerItem " + go + " " + go.tag);
                foreach (var cube in cubes)
                {
                    if (cube == null)
                        continue;
                    //Debug.Log(item.gameObject.name);
                    if (go.transform == cube.transform)
                    {
                        //Debug.Log("got PointerItem " + go);
                        return cube;
                    }
                }
            }
        }
        return null;
    }

    public void InputPanelClick(PointerEventData eventData)
    {
        var item = GetPointerItem(eventData);
        if (item != null)
        {
            item.OnClicked();
            return;
        }
    }

    public void InputPanelRelease(PointerEventData eventData)
    {
        FadeAllOutline();
    }

    public void InputPanelDown(PointerEventData eventData)
    {
        //Debug.Log("InputPanelDown " + eventData);
        var item = GetPointerItem(eventData);
        //Debug.Log(item);
        if (item != null && item.interactable)
        {
            //Debug.Log(OutlineStyle.Thick);
            item.outlineStyle = OutlineStyle.Thick;
            return;
        }
    }
}
