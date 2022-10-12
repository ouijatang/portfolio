using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject blinker;
    CanvasGroup _cg;
    RectTransform _rect;
    public bool startShow;
    public Image bg;

    private void Awake()
    {
        _cg = GetComponent<CanvasGroup>();
        _rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (startShow)
            Show();
        else
            Hide();
    }

    public void Show()
    {
        blinker.SetActive(false);
        _cg.interactable = true;
        _cg.DOKill();
        _cg.DOFade(1, 1.5f);
    }

    public void Hide()
    {
        _cg.interactable = false;
        _cg.DOKill();
        _cg.DOFade(0, 1.5f);
    }

    public void SetBg(Sprite sp)
    {
        bg.sprite = sp;
    }
}
