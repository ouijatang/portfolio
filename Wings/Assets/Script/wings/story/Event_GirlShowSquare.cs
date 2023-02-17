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

    public GameObject bubbleTalk1;
    public float t1 = 0.35f;
    public float t2 = 2f;

    protected override void OnTrigger()
    {
        SoundSystem.instance.Play("createCanvas");
        dragBg.enabled = false;
        walker.StopWalk();
        squareBackground.DOFade(1, 0.6f);

        StartCoroutine(BubbleTalk(t1));
        StartCoroutine(ZoomOut(t2));
    }

    IEnumerator BubbleTalk(float delay)
    {
        yield return new WaitForSeconds(delay);
        bubbleTalk1.SetActive(true);
    }

    IEnumerator ZoomOut(float delay)
    {
        yield return new WaitForSeconds(delay);
        wholeImgRect.DOAnchorPos(new Vector2(-1005, -114), 3f);
        wholeImgRect.DOScale(0.6f, 3f);

        townSquare.ShowPeople();
    }
}