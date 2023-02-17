using UnityEngine;
using System.Collections;
using com;
using UnityEngine.UI;
using DG.Tweening;

public class Event_GirlShowSquare : EventTrigger
{
    public CanvasObject dragBg;
    public CharacterActor walker;
    public Image squareBackground;
    public RectTransform wholeImgRect;
    public TownSquare townSquare;
    public Image ladder;

    public GameObject bubbleTalk1;
    public float t1 = 0.35f;
    public float t2 = 4.5f;
    public float t3 = 6.5f;
    public AudioSource horrorAmbience;

    protected override void OnTrigger()
    {
        SoundSystem.instance.Play("createCanvas");
        dragBg.enabled = false;
        walker.StopWalk();
        squareBackground.DOFade(1, 0.6f);
        ladder.gameObject.SetActive(true);
        ladder.DOFade(1, 0.6f);

        StartCoroutine(BubbleTalk(t1));
        StartCoroutine(ZoomOut(t2));
        StartCoroutine(EnableInteractions(t3));
    }

    IEnumerator BubbleTalk(float delay)
    {
        yield return new WaitForSeconds(delay);
        bubbleTalk1.SetActive(true);
    }

    IEnumerator ZoomOut(float delay)
    {
        yield return new WaitForSeconds(delay);
        horrorAmbience.Play();

        yield return new WaitForSeconds(1.1f);
        wholeImgRect.DOAnchorPos(new Vector2(-914, -82), 4f);
        wholeImgRect.DOScale(0.7f, 4f);

        townSquare.ShowPeople();
    }

    IEnumerator EnableInteractions(float delay)
    {
        yield return new WaitForSeconds(delay);

        var cos = ladder.gameObject.GetComponents<CanvasObject>();
        foreach (var co in cos)
        {
            co.enabled = true;
        }
    }
}