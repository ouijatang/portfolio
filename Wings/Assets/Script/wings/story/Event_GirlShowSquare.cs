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

    protected override void OnTrigger()
    {
        SoundSystem.instance.Play("createCanvas");
        dragBg.enabled = false;
        walker.StopWalk();
        squareBackground.DOFade(1, 0.5f);
        wholeImgRect.DOAnchorPos(new Vector2(-1005, -114), 3f);
        wholeImgRect.DOScale(0.6f, 3f);

        townSquare.ShowPeople();
    }
}