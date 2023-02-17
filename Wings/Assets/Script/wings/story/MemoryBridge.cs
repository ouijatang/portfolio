using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class MemoryBridge : MonoBehaviour
{
    public static MemoryBridge instance;

    public RectTransform rect;
    public Vector2 startAnchoredPos;
    public Vector2 endAnchoredPos;
    public float startScale;
    public float endScale;

    public float t_bridge;
    public float t_girls;
    public float t_scissors;

    public Image imgBridge;
    public Image imgGirls;
    public Image imgScissors;

    private void Awake()
    {
        instance = this;
    }

    public void StartShowMemory()
    {
        rect.anchoredPosition = startAnchoredPos;
        rect.transform.localScale = startScale * Vector3.one;

        StartCoroutine(Zoom());
        StartCoroutine(ShowBridge());
        StartCoroutine(ShowGirls());
        StartCoroutine(ShowScissors());
    }

    IEnumerator Zoom()
    {
        yield return new WaitForSeconds(1);
        rect.DOScale(endScale, 4f).SetEase(Ease.InOutCubic);
        rect.DOAnchorPos(endAnchoredPos, 4f).SetEase(Ease.InOutCubic);
    }

    IEnumerator ShowBridge()
    {
        yield return new WaitForSeconds(t_bridge);
        imgBridge.DOFade(1, 1);
    }

    IEnumerator ShowGirls()
    {
        yield return new WaitForSeconds(t_girls);
        imgGirls.DOFade(1, 1);
    }

    IEnumerator ShowScissors()
    {
        yield return new WaitForSeconds(t_scissors);
        imgScissors.DOFade(1, 1);
    }
}
