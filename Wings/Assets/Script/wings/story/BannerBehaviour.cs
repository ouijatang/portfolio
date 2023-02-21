using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using com;

public class BannerBehaviour : MonoBehaviour
{
    public Image originalImg;
    public Image finalImg;
    public MoveSinBehaviour msb;
    public CanvasGroup cgFin;
    public CanvasGroup cgLogo;
    public GameObject[] peopleToHide;

    public float delay1;
    public float delay2;
    public float delay3;
    public float delay4;
    public float delay5;

    public float dropDuration;

    public Vector2 finalDropAnchoredPos;
    public RectTransform rect;
    public string postDropSound = "crowd";

    public void Cut()
    {
        msb.enabled = false;
        StartCoroutine(CutBannerProcess());
    }

    IEnumerator CutBannerProcess()
    {
        yield return new WaitForSeconds(delay1);
        SoundSystem.instance.Play("scissor");
        yield return new WaitForSeconds(delay2);
        SoundSystem.instance.Play("flag");
        rect.DOAnchorPos(finalDropAnchoredPos, dropDuration).SetEase(Ease.InQuad);
        yield return new WaitForSeconds(delay3);
        originalImg.DOFade(0, 0.35f);
        yield return new WaitForSeconds(delay4);
        finalImg.DOFade(1, 0.35f);
        foreach (var p in peopleToHide)
            p.SetActive(false);

        SoundSystem.instance.Play(postDropSound);
        yield return new WaitForSeconds(delay5);
        Debug.Log("Finish");
        cgFin.DOFade(1, 3);
        cgLogo.DOFade(1, 1.5f).SetDelay(1.5f);
    }
}
