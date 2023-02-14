using UnityEngine;
using System.Collections;

public class Event_GirlShowLadder : EventTrigger
{
    public GameObject ladder;

    protected override void OnTrigger()
    {
        ladder.SetActive(true);
        //color alpha tween
    }
}