using UnityEngine;
using System.Collections;

public class ClickFeedback : MonoBehaviour
{
    public bool locked;

    protected virtual void DoAnime()
    {
    }

    public void OnClicked()
    {
        DoAnime();
    }
}
