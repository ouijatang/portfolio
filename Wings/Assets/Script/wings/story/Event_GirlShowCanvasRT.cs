using UnityEngine;
using System.Collections;
using com;

public class Event_GirlShowCanvasRT : EventTrigger
{
    public CanvasBehaviour targetCanvas;
    public CanvasObject dragBg;
    public CharacterActor walker;

    protected override void OnTrigger()
    {
        //targetCanvas.SetBg();
        targetCanvas.Show();
        SoundSystem.instance.Play("createCanvas");
        dragBg.enabled = false;
        walker.StopWalk();
    }
}