using UnityEngine;
using System.Collections;

public class MaskAffectAllChildren : MonoBehaviour
{
    public int backSortingOrder;
    public int frontSortingOrder;
    public bool t;
    SpriteMask _mask;

    void Start()
    {
        _mask = GetComponent<SpriteMask>();
        //  int so = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

    }

    // Update is called once per frame
    void Update()
    {
        if (t)
        {
            t = false;
            _mask.isCustomRangeActive = true;
            _mask.backSortingOrder = backSortingOrder;
            _mask.frontSortingOrder = frontSortingOrder;
        }
    }
}
